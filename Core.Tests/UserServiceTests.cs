using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DatabaseModel;
using Core.DataTransferObjects;
using Core.Services;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Core.Tests
{
    public class UserServiceTests
    {
        private readonly Seeder _seeder;

        public UserServiceTests()
        {
            _seeder = new Seeder();
        }

        [Fact]
        public async Task GetTest()
        {
            // Arrange

            // Act
            var users = await _seeder.CreateUserService().GetAsync();

            // Assert
            users.Should().HaveCount(4);
        }

        [Fact]
        public async Task GetByIdTest()
        {
            // Arrange

            // Act
            var user = await _seeder.CreateUserService().GetAsync(_seeder.TimeBarcodeUser.Id);

            // Assert
            user
                .Should()
                .NotBeNull()
                .And
                .Match<ApplicationUser>(u => u.Id == _seeder.TimeBarcodeUser.Id);
        }

        [Theory]
        [MemberData(nameof(MakePaymentTestData))]
        public async Task MakePaymentTest(PaymentReason paymentReason, decimal difference)
        {
            // Arrange
            var userId = _seeder.PaymentUser.Id;
            var userOpenSumBefore = (await _seeder.CreateUserService().GetOpenAmountAsync(userId));
            var nearbyTime = DateTime.Now;

            // Act
            var paymentCreatedResponse =
                await _seeder.CreateUserService().MakePaymentAsync(userId, 10m, paymentReason);
            var openSumAfter = (await _seeder.CreateUserService().GetOpenAmountAsync(userId));

            // Assert
            openSumAfter.Should().Be(userOpenSumBefore + difference);
            openSumAfter.Should().Be(paymentCreatedResponse.OpenAmount);
            var payment = paymentCreatedResponse.Payment;
            payment.Should().NotBeNull();
            payment.CreatedAt.Should().BeAfter(nearbyTime).And.BeBefore(DateTime.Now);
            payment.Reason.Should().Be(paymentReason);
            payment.ApplicationUserId.Should().Be(userId);
            payment.Amount.Should().Be(paymentReason == PaymentReason.Payout ? -10m : 10m);
            
        }
        
        public static IEnumerable<object[]> MakePaymentTestData()
        {
            yield return new object[] {PaymentReason.Deposit, -10m};
            yield return new object[] {PaymentReason.Correction, -10m};
            yield return new object[] {PaymentReason.Payout, 10m};
            yield return new object[] {PaymentReason.PurchaseSettlement, -10m};
        }

        [Fact]
        public async Task DeletePaymentTest()
        {
            // Arrange
            var payment = _seeder.Payment;
            var user = _seeder.PaymentUser;
            var openAmountBefore = await _seeder.CreateUserService().GetOpenAmountAsync(user.Id);
            // Act
            var returnedAmount = await _seeder.CreateUserService().DeletePaymentAsync(user.Id, payment.Id);
            var openAmountAfter = await _seeder.CreateUserService().GetOpenAmountAsync(user.Id);

            // Assert   
            returnedAmount
                .Should().Be(openAmountAfter)
                .And
                .Be(openAmountBefore + payment.Amount);
        }

        [Fact]
        public async Task DeleteTest()
        {
            // Arrange
            
            var user = _seeder.CreateUserService().GetAsync(_seeder.PaymentBarcodeUser.Id);

            // Act


            // Assert   
        }

        [Fact]
        public async Task BuyProductByCodeTest()
        {
            // Arrange
            var userId = _seeder.ProductUser.Id;
            var amountBefore = await _seeder.CreateUserService().GetOpenAmountAsync(userId);
            
            // Act
            var response = await _seeder.CreateUserService().BuyProduct(userId, _seeder.Product.Id);

            // Assert   
            response.Should().NotBeNull();
            response.OpenAmount.Should().Be(amountBefore + Seeder.ProductPrice);
            response.OpenAmount.Should().Be(await _seeder.CreateUserService().GetOpenAmountAsync(userId));
            var sale = response.Sale;
            sale.Should().NotBeNull();
            sale.Amount.Should().Be(Seeder.ProductPrice);
            sale.Product?.Id.Should().Be(_seeder.Product.Id);
        }

        [Fact]
        public async Task BuyProductByIdTest()
        {
            // Arrange
            var userId = _seeder.ProductUser.Id;
            var amountBefore = await _seeder.CreateUserService().GetOpenAmountAsync(userId);
            
            // Act
            var response = await _seeder.CreateUserService().BuyProduct(userId, Seeder.ProductCodeString);

            // Assert   
            response.Should().NotBeNull();
            response.OpenAmount.Should().Be(amountBefore + Seeder.ProductPrice);
            response.OpenAmount.Should().Be(await _seeder.CreateUserService().GetOpenAmountAsync(userId));
            var sale = response.Sale;
            sale.Should().NotBeNull();
            sale.Amount.Should().Be(Seeder.ProductPrice);
            sale.Product?.Id.Should().Be(_seeder.Product.Id);
        }

        [Fact]
        public async Task BuyProductByNonExistentCodeTest()
        {
            // Arrange
            var userId = _seeder.ProductUser.Id;
            
            // Act
            
            Func<Task> act  = async () =>await _seeder.CreateUserService().BuyProduct(userId, Seeder.NonExistentCodeString);

            
            // Assert   
            (await act.Should().ThrowAsync<EntityNotFoundException<ProductBarcode>>())
                .And.Id.Should().Be(Seeder.NonExistentCodeString);
        }

        [Fact]
        public async Task BuyProductForNotActivatedUserTest()
        {
            var saleOverview = await _seeder.CreateContext().Sales
                .GroupBy(s => new {Year = s.CreatedAt.Year, Month = s.CreatedAt.Month})
                .Select(g => new
                {
                    g.Key.Month,
                    g.Key.Year, 
                    Sum = g.Sum(s => s.Amount),
                    Count = g.Count()
                })
                .ToListAsync();
            
            // Arrange
            var userId = _seeder.PaymentBarcodeUser.Id;
            
            // Act
            
            Func<Task> act  = async () =>await _seeder.CreateUserService().BuyProduct(userId, Seeder.ProductCodeString);

            
            // Assert   
            (await act.Should().ThrowAsync<Exception>())
                .And.Message.Should().Be(ExceptionMessages.UserNotEnabledForProducts);
        }

        [Fact]
        public async Task BuyByCodeTest()
        {
            // Arrange
            var userId = _seeder.PaymentBarcodeUser.Id;
            var amountBefore = await _seeder.CreateUserService().GetOpenAmountAsync(userId);
            
            // Act
            var response = await _seeder.CreateUserService().BuyByCode(userId, Seeder.MoneyCodeString);

            // Assert   
            response.Should().NotBeNull();
            response.OpenAmount.Should().Be(amountBefore + _seeder.PaymentBarcode.Amount);
            response.OpenAmount.Should().Be(await _seeder.CreateUserService().GetOpenAmountAsync(userId));
            var sale = response.Sale;
            sale.Should().NotBeNull();
            sale.Amount.Should().Be(_seeder.PaymentBarcode.Amount);
            sale.UserPaymentBarcodeId.Should().Be(_seeder.PaymentBarcode.Id);  
        }

        [Fact]
        public async Task BuyByNonExistentCodeTest()
        {
            // Arrange
            var userId = _seeder.PaymentBarcodeUser.Id;
            
            // Act
            
            Func<Task> act  = async () =>await _seeder.CreateUserService().BuyByCode(userId, Seeder.NonExistentCodeString);

            
            // Assert   
            (await act.Should().ThrowAsync<EntityNotFoundException<UserBarcode>>())
                .And.Id.Should().Be(Seeder.NonExistentCodeString);
        }

        [Fact]
        public async Task BuyByCodeForProductUserTest()
        {
            // Arrange
            var userId = _seeder.ProductUser.Id;
            
            // Act
            
            Func<Task> act  = async () =>await _seeder.CreateUserService().BuyByCode(userId, Seeder.NonExistentCodeString);

            
            // Assert   
            (await act.Should().ThrowAsync<Exception>())
                .And.Message.Should().Be(ExceptionMessages.UserNotAllowedForPaymentCodes);
        }

        [Fact]
        public async Task BuyByAmountNonProductUserTest()
        {
            // Arrange
            var userId = _seeder.PaymentBarcodeUser.Id;
            var amountBefore = await _seeder.CreateUserService().GetOpenAmountAsync(userId);
            var buyAmount = 1.5m;
            
            // Act
            var response = await _seeder.CreateUserService().BuyByAmount(userId, buyAmount);

            // Assert   
            response.Should().NotBeNull();
            response.OpenAmount.Should().Be(amountBefore + buyAmount);
            response.OpenAmount.Should().Be(await _seeder.CreateUserService().GetOpenAmountAsync(userId));
            var sale = response.Sale;
            sale.Should().NotBeNull();
            sale.Amount.Should().Be(buyAmount);  
        }

        [Fact]
        public async Task BuyByAmountProductUserTest()
        {
            // Arrange
            var userId = _seeder.ProductUser.Id;
            var amountBefore = await _seeder.CreateUserService().GetOpenAmountAsync(userId);
            var buyAmount = 1.5m;
            
            // Act
            var response = await _seeder.CreateUserService().BuyByAmount(userId, buyAmount);

            // Assert   
            response.Should().NotBeNull();
            response.OpenAmount.Should().Be(amountBefore + buyAmount);
            response.OpenAmount.Should().Be(await _seeder.CreateUserService().GetOpenAmountAsync(userId));
            var sale = response.Sale;
            sale.Should().NotBeNull();
            sale.Amount.Should().Be(buyAmount);  
        }

        [Fact]
        public async Task GetOpenAmount()
        {
            // Arrange
            var user = _seeder.PaymentBarcodeUser;
            var amountFromInit = user.Sales.Sum(s => s.Amount);

            // Act
            var amountFromService = await _seeder.CreateUserService().GetOpenAmountAsync(user.Id);

            // Assert   
            amountFromService.Should().Be(amountFromInit);
        }

        [Fact]
        public async Task GetUserOverview()
        {
            // Arrange
            

            // Act

            // Assert   
        }
    }
}