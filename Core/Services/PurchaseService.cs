using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class PurchaseService
    {
        private DataContext _context;

        public PurchaseService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Purchase>> Get()
        {
            return await _context.Purchases
                .AddDefaultIncludes()
                .ToListAsync();
        }
        public async Task<Purchase> Get(Guid purchaseId)
        {
            var purchase = await _context.Purchases
                .AddDefaultIncludes()
                .FirstOrDefaultAsync(p => p.Id == purchaseId);
            if (purchase ==null)
                throw new EntityNotFoundException<Purchase>();
            return purchase;
        }

        public async Task<Purchase> Add(Purchase purchase)
        {
            var productIds = purchase.Products.Select(p => p.ProductId).ToArray();
            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
            foreach (var line in purchase.Products)
            {
                var product = products.First(p => p.Id == line.Id);
                product.StockInventory += line.Amount;
            }
            await _context.AddAsync(purchase);
            await _context.SaveChangesAsync();
            return purchase;
        }

        public async Task AddInvoice(Guid purchaseId, byte[] invoice)
        {
            var purchase = await Get(purchaseId);
            purchase.Invoice = invoice;
            await _context.SaveChangesAsync();
        }

        public async Task SettlePurchase(Guid purchaseId, Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                throw new EntityNotFoundException<ApplicationUser>();
            var purchase = await Get(purchaseId);
            user.Payments.Add(new Payment()
            {
                Amount = purchase.Price,
                Reason = PaymentReason.PurchaseSettlement,
                ApplicationUser = user
            });
            await _context.SaveChangesAsync();
        }
        
    }
    
    
}