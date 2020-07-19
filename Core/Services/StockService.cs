using System;
using System.Threading.Tasks;
using Core.DatabaseModel;

namespace Core.Services
{
    public class StockService
    {
        private DataContext _context;

        public StockService(DataContext context)
        {
            _context = context;
        }

        public async Task MoveProductToShelf(Guid productId, int amount)
        {
            var product = await Get(productId);
            await _context.StockChanges.AddAsync(new ShelfMovement()
            {
                Amount = amount,
                Product = product
            });
            product.ShelfInventory += amount;
            product.StockInventory -= amount;
            await _context.SaveChangesAsync();
        }

        public async Task DisposeProductFromShelf(Guid productId, int amount, DisposalType type)
        {
            var product = await Get(productId);
            await _context.StockChanges.AddAsync(new ShelfDisposal()
            {
                Amount = amount,
                Type = type,
                Product = product
            });
            product.ShelfInventory -= amount;
            await _context.SaveChangesAsync();
        }

        public async Task DisposeProductFromStock(Guid productId, int amount, DisposalType type)
        {
            var product = await Get(productId);
            await _context.StockChanges.AddAsync(new StockDisposal()
            {
                Amount = amount,
                Type = type,
                Product = product
            });
            product.StockInventory -= amount;
            await _context.SaveChangesAsync();
        }

        public async Task SetProductInventory(Guid productId, int? shelfAmount, int? stockAmount)
        {
            var product = await Get(productId);
            await _context.StockChanges.AddAsync(new Correction()
            {
                ShelfAmount = shelfAmount,
                StockAmount = stockAmount,
                Product = product
            });
            product.ShelfInventory = shelfAmount ?? product.ShelfInventory;
            product.StockInventory = stockAmount ?? product.StockInventory;
            await _context.SaveChangesAsync();
        }

        public async Task<Product> Get(Guid productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                throw new EntityNotFoundException<Product>();
            return product;
        }
    }
}