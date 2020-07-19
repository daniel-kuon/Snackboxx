using System;

namespace Core.DatabaseModel
{
    public class ProductPurchase : StockChange
    {
        public int Amount { get; set; }
        public DateTime BestBefore { get; set; }
        public Guid PurchaseId { get; set; }
        public Purchase Purchase { get; set; }
        public decimal Price { get; set; }
        public decimal ExpectedSellingPrice { get; set; }
    }
}