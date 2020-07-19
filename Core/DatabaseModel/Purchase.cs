using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DatabaseModel
{
    public class Purchase: IEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Supplier { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal Discount { get; set; }
        public decimal Price { get; set; }
        public decimal ShipmentCosts { get; set; }
        public DateTime Time { get; set; }
        public string? Url { get; set; }
        public byte[]? Invoice { get; set; }
        public List<ProductPurchase> Products { get; set; }
    }
}