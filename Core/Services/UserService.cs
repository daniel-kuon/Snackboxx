using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.DatabaseModel;
using Core.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class UserService : EntityService<ApplicationUser>
    {
        public UserService(DataContext context) : base(context)
        {
        }

        public async Task<PaymentCreatedResponse> MakePaymentAsync(Guid userId, decimal amount, PaymentReason reason)
        {
            await EnsureExists(userId);
            if (reason == PaymentReason.Payout)
                amount *= -1;
            var payment = new Payment
                {Amount = amount, Reason = reason, CreatedAt = DateTime.Now, ApplicationUserId = userId};
            await Context.Payments.AddAsync(payment);
            await Context.SaveChangesAsync();

            return new PaymentCreatedResponse(payment, await GetOpenAmountAsync(userId));
        }

        public async Task<decimal> DeletePaymentAsync(Guid userId, Guid paymentId)
        {
            await EnsureExists(userId);
            var payment =
                await Context.Payments
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.ApplicationUserId == userId && p.Id == paymentId);
            if (payment == null)
                throw new EntityNotFoundException<Payment>(paymentId);
            Context.Payments.Remove(payment);
            await Context.SaveChangesAsync();
            return await GetOpenAmountAsync(userId);
        }

        public override async Task UpdateAsync(ApplicationUser entity)
        {
            entity.Payments = null!;
            entity.Sales = null!;
            await base.UpdateAsync(entity);
        }

        public override async Task DeleteAsync(Guid id)
        {
            var openAmount = await GetOpenAmountAsync(id);
            if (openAmount != 0)
                await MakePaymentAsync(id, -openAmount, PaymentReason.Correction);
            await base.DeleteAsync(id);
        }

        public override async Task DeleteAsync(ApplicationUser entity)
        {
            var openAmount = await GetOpenAmountAsync(entity.Id);
            if (openAmount != 0)
                await MakePaymentAsync(entity.Id, -openAmount, PaymentReason.Correction);
        }

        public async Task<SaleCreatedResponse> BuyProduct(Guid userId, Guid productId)
        {
            var user = await GetAsync(userId, false);
            if (!user.ProductBarcodesEnabled)
                throw new Exception(ExceptionMessages.UserNotEnabledForProducts);
            var product = await GetAsync<Product>(productId);
            return await BuyProduct(userId, product);
        }

        public async Task<SaleCreatedResponse> BuyProduct(Guid userId, string barcode)
        {
            var user = await GetAsync(userId, false);
            if (!user.ProductBarcodesEnabled)
                throw new Exception(ExceptionMessages.UserNotEnabledForProducts);
            var product = await Context.ProductBarcodes
                .Where(b => b.Code == barcode)
                .Select(b => b.Product)
                .FirstOrDefaultAsync();
            if (product == null)
                throw new EntityNotFoundException<ProductBarcode>(barcode);
            return await BuyProduct(userId, product);
        }

        private async Task<SaleCreatedResponse> BuyProduct(Guid userId, Product product)
        {
            var sale = new Sale
            {
                Amount = product.Price,
                Product = product,
                ApplicationUserId = userId,
                SnackPoints = product.SnackPoints
            };
            await Context.Sales.AddAsync(sale);
            product.ShelfInventory -= 1;
            if (product.ShelfInventory == -1)
            {
                product.ShelfInventory = 0;
                product.StockInventory -= 1;
            }

            await Context.SaveChangesAsync();
            return new SaleCreatedResponse(sale, await GetOpenAmountAsync(userId));
        }

        public async Task<SaleCreatedResponse> BuyByCode(Guid userId, string code)
        {
            var user = await GetAsync(userId, false);
            if (user.ProductBarcodesEnabled)
                throw new Exception(ExceptionMessages.UserNotAllowedForPaymentCodes);
            var barcode = await Context.UserBarcodes
                .AsNoTracking()
                .OfType<UserPaymentBarcode>()
                .FirstOrDefaultAsync(b => b.ApplicationUserId == userId && b.Code == code);
            if (barcode == null)
                throw new EntityNotFoundException<UserBarcode>(code);
            var sale = new Sale
            {
                Amount = barcode.Amount,
                ApplicationUserId = userId,
                UserPaymentBarcodeId = barcode.Id
            };
            await Context.Sales.AddAsync(sale);
            await Context.SaveChangesAsync();
            return new SaleCreatedResponse(sale, await GetOpenAmountAsync(userId));
        }

        public async Task<SaleCreatedResponse> BuyByAmount(Guid userId, decimal amount)
        {
            await EnsureExists(userId);
            var sale = new Sale
            {
                Amount = amount,
                ApplicationUserId = userId
            };
            await Context.Sales.AddAsync(sale);
            await Context.SaveChangesAsync();
            return new SaleCreatedResponse(sale, await GetOpenAmountAsync(userId));
        }

        public async Task<decimal> GetOpenAmountAsync(Guid userId)
        {
            await EnsureExists(userId);
            var userPaymentSumTask = await Context.Payments
                .AsNoTracking()
                .Where(p => p.ApplicationUserId == userId)
                .Select(p => p.Amount)
                .ToListAsync();
            var userSaleSumTask = await Context.Sales
                .AsNoTracking()
                .Where(p => p.ApplicationUserId == userId)
                .Select(p => p.Amount)
                .ToListAsync();
            return userSaleSumTask.Sum() - userPaymentSumTask.Sum();
        }

        public async Task<IEnumerable<UserOverview>> GetUserOverviewAsync()
        {
            var users = await Context.Users
                .AsNoTracking()
                .OrderBy(u => u.UserName)
                .ToListAsync();
            var sales = await Context.Sales
                .AsNoTracking()
                .Where(s => s.ApplicationUserId != null)
                .GroupBy(s => s.ApplicationUserId)
                .Select(s => new
                {
                    Id = s.Key,
                    Amount = s.Sum(s2 => s2.Amount),
                    LastSale = s.Max(s2 => s2.CreatedAt)
                })
                .ToListAsync();
            var payments = await Context.Payments
                .AsNoTracking()
                .Where(s => s.ApplicationUserId != null)
                .GroupBy(s => s.ApplicationUserId)
                .Select(s => new {Id = s.Key, Amount = s.Sum(s2 => s2.Amount)})
                .ToListAsync();
            return users.Select(u =>
            {
                var sale = sales.FirstOrDefault(s => s.Id == u.Id);
                var paymentsAmount = payments.FirstOrDefault(p => p.Id == u.Id)?.Amount ?? 0;
                return new UserOverview
                {
                    Id = u.Id,
                    Mail = u.Email,
                    UserName = u.UserName,
                    LastSale = sale?.LastSale,
                    OpenAmount = (sale?.Amount ?? 0) - paymentsAmount,
                    ProductBarcodesEnabled = u.ProductBarcodesEnabled
                };
            });
        }

        public async Task<UserOverview> GetUserOverviewAsync(Guid id)
        {
            var user = await GetAsync(id);
            return GetUserOverview(user);
        }

        public UserOverview GetUserOverview(ApplicationUser user)
        {
            return new UserOverview
            {
                Id = user.Id,
                Mail = user.Email,
                UserName = user.UserName,
                LastSale = user.Sales.Any()
                    ? user.Sales.Max(s => s.CreatedAt)
                    : (DateTime?) null,
                OpenAmount = user.Sales.Sum(s => s.Amount) - user.Payments.Sum(p => p.Amount),
                ProductBarcodesEnabled = user.ProductBarcodesEnabled,
                IsInOffice = user.TimeTrackingEnabled &&
                             user.TimeEntries.Any() &&
                             user.TimeEntries
                                 .OrderByDescending(t => t.StartTime)
                                 .Last().EndTime == null,
                TimeCodeEnabled = user.TimeTrackingEnabled
            };
        }

        public async Task<TimeTrackingResponse> TogglePresenceAsync(string userTimeCode)
        {
            var timeCode = await Context.UserBarcodes
                .AsNoTracking()
                .Where(c => c.Code == userTimeCode && c is UserTimeBarcode)
                .Include(c => c.ApplicationUser)
                .ThenInclude(u => u.TimeEntries)
                .Include(c => c.ApplicationUser)
                .ThenInclude(u => u.Sales)
                .FirstOrDefaultAsync();
            if (timeCode == null)
                throw new EntityNotFoundException<UserTimeBarcode>(userTimeCode);
            return await TogglePresenceAsync(timeCode.ApplicationUser);
        }

        private async Task<TimeTrackingResponse> TogglePresenceAsync(ApplicationUser user)
        {
            if (user.TimeTrackingEnabled)
                throw new Exception(ExceptionMessages.TimeTrackingNotEnabledForUser);
            var lastTimeEntry = user.TimeEntries
                .OrderByDescending(t => t.StartTime)
                .FirstOrDefault(t => t.ApplicationUserId == user.Id);
            if (lastTimeEntry == null || lastTimeEntry.EndTime != null)
            {
                await Context.TimeEntries.AddAsync(new TimeEntry()
                {
                    StartTime = DateTime.Now,
                    ApplicationUserId = user.Id
                });
                return new TimeTrackingResponse()
                {
                    IsPresent = true,
                    UserOverview = GetUserOverview(user)
                };
            }
            else
            {
                Context.Attach(lastTimeEntry);
                lastTimeEntry.EndTime = DateTime.Now;
                await Context.SaveChangesAsync();
                return new TimeTrackingResponse()
                {
                    IsPresent = false,
                    PresenceTime = lastTimeEntry.EndTime - lastTimeEntry.StartTime,
                    UserOverview = GetUserOverview(user)
                };
            }
        }

        public async Task<TimeTrackingResponse> TogglePresenceAsync(Guid userId)
        {
            return await TogglePresenceAsync(await GetAsync(userId));
        }
    }
}