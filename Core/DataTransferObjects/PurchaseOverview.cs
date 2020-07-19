using System;

namespace Core.DataTransferObjects
{
    public class PurchaseOverview
    {
        public Guid Id { get; set; }
        public string Supplier { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public bool IsSettled { get; set; }
    }
}