using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.DatabaseModel;
using Core.Services;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Core.Tests
{
    public class Seeder
    {
        private DbContextOptions<DataContext> _options;
        private DataContext _context;
        public const string MoneyCodeString = "Money";
        public const string TimeCodeString = "Time";
        public const string ProductCodeString = "ProductCode";
        public const string NonExistentCodeString = "NonExistentCode";
        public const string ProductPurchaseCodeString = "ProductPurchaseCode";
        public const decimal ProductPrice = 0.5m;
        public const decimal UserOpenAmount = 1;

        public Seeder()
        {
            _options =
                new DbContextOptionsBuilder<DataContext>()
                    .EnableSensitiveDataLogging()
                    //.UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .UseSqlite("DataSource=:memory:")
                    //.UseSqlServer("Data Source=.;Initial Catalog=SnackboxUnitTests;Integrated Security=True")
                    .Options;
            _context = new DataContext(_options);
            _context.Database.OpenConnection();
            _context.Database.EnsureCreated();
//            _context.Database.ExecuteSqlRaw(@"DECLARE @Nombre NVARCHAR(MAX);
//DECLARE curso CURSOR FAST_FORWARD 
//FOR 
//Select Object_name(object_id) AS Nombre from sys.objects where type = 'U'
//
//OPEN curso
//FETCH NEXT FROM curso INTO @Nombre
//
//WHILE (@@FETCH_STATUS <> -1)
//BEGIN
//IF (@@FETCH_STATUS <> -2)
//BEGIN
//DECLARE @statement NVARCHAR(200);
//SET @statement = 'DELETE FROM ' + @Nombre;
//print @statement
//execute sp_executesql @statement;
//END
//FETCH NEXT FROM curso INTO @Nombre
//END
//CLOSE curso
//DEALLOCATE curso");

            Product = new Product
            {
                Name = "ProductName",
                Price = 0.5m,
                ProductBarcodes = new List<ProductBarcode> {ProductBarcode, ProductPurchaseBarcode},
                ShelfInventory = 10,
                StockInventory = 10,
                Prices = new List<ProductPrice>
                {
                    new ProductPrice {Price = ProductPrice}
                },
                DefaultSellingPrice = 0.5m
            };
            TimeBarcodeUser = new ApplicationUser
            {
                Barcodes = new List<UserBarcode> {TimeBarcode},
                Email = "TimeBarcodeUser@test.de"
            };
            PaymentBarcodeUser = new ApplicationUser
            {
                Barcodes = new List<UserBarcode> {PaymentBarcode},
                Email = "PaymentBarcodeUser@test.de",
                Sales = CreatePaymentCodeSales()
            };
            PaymentUser = new ApplicationUser
            {
                Email = "PaymentUser@test.de",
                Payments = new List<Payment> {Payment}
            };
            ProductUser = new ApplicationUser
            {
                Email = "ProductUser@test.de",
                ProductBarcodesEnabled = true,
                Sales = CreateProductSales()
            };
            Purchase = new Purchase
            {
                Price = 10,
                Products = new List<ProductPurchase>
                {
                    new ProductPurchase
                    {
                        Amount = 21,
                        Product = Product,
                        Price = 5m,
                        ExpectedSellingPrice = 0.5m,
                        BestBefore = DateTime.Today.AddMonths(3)
                    }
                },
                Time = DateTime.Now.AddDays(-1),
                Discount = 0.05m,
                Supplier = "Supplier",
                DiscountPercent = 0,
                ShipmentCosts = 2m,
            };
//            var benchmarkUser = new ApplicationUser()
//            {
//                Email = "benchmarkUser@test.de",
//                Payments = Enumerable.Range(0,10_000).Select(i => new Payment() {Amount = 1m}).ToList(),
//                Sales = Enumerable.Range(0,10_000).Select(i => new Sale() {Amount = 1m}).ToList(),
//            };
            _context.AddRange(new object[]
            {
                PaymentUser, TimeBarcodeUser, PaymentBarcodeUser, Purchase, Product, ProductUser
            });
            _context.SaveChanges();
        }

        private List<Sale> CreateProductSales()
        {
            var rnd = new Random();
            return Enumerable
                .Range(0, rnd.Next(0, 30))
                .Select(_ =>
                            new Sale()
                            {
                                Amount = (decimal) rnd.NextDouble(),
                                Product = Product,
                                SnackPoints = rnd.Next(1,10)
                            })
                .ToList();
        }

        private List<Sale> CreatePaymentCodeSales()
        {
            var rnd = new Random();
            return Enumerable
                .Range(0, rnd.Next(0, 30))
                .Select(_ =>
                            new Sale()
                            {
                                Amount = (decimal) rnd.NextDouble(),
                                UserPaymentBarcode = PaymentBarcode,
                                SnackPoints = rnd.Next(1,10)
                            })
                .ToList();
        }

        public DataContext CreateContext()
        {
            _context.ChangeTracker.Entries().ForEach(e => e.State = EntityState.Detached);
            return _context;
        }

        public ApplicationUser PaymentUser { get; }
        public ApplicationUser TimeBarcodeUser { get; }
        public ApplicationUser PaymentBarcodeUser { get; }
        public ApplicationUser ProductUser { get; }
        public Purchase Purchase { get; }
        public Product Product { get; }

        public Payment Payment { get; } =
            new Payment
            {
                Amount = 1m,
                Reason = PaymentReason.Deposit
            };

        public UserTimeBarcode TimeBarcode { get; } = new UserTimeBarcode
        {
            Code = TimeCodeString,
        };

        public ProductBarcode ProductBarcode { get; } =
            new ProductBarcode
            {
                Amount = 24,
                Code = ProductPurchaseCodeString,
            };

        public ProductBarcode ProductPurchaseBarcode { get; } = new ProductBarcode
        {
            Amount = 1,
            Code = ProductCodeString,
        };

        public UserPaymentBarcode PaymentBarcode { get; } = new UserPaymentBarcode
        {
            Amount = 0.5m,
            Code = MoneyCodeString,
        };

        public UserService CreateUserService() => new UserService(CreateContext());
        public PurchaseService CreatePurchaseService() => new PurchaseService(CreateContext());
        public StockService CreateStockService() => new StockService(CreateContext());
        public AdminService CreateAdminService() => new AdminService(CreateContext());
    }
}