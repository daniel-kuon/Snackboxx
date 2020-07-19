using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Attributes;

namespace Core.DatabaseModel
{
    public class Product:IUpdateableEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public string Name { get; set; }
        public byte[]? Image { get; set; }
        [NonPublicData] 
        public decimal DefaultSellingPrice { get; set; }
        [NonPublicData]
        public int StockInventory { get; set; }
        [NonPublicData]
        public int ShelfInventory { get; set; }
        [NonPublicData]
        public List<ProductBarcode> ProductBarcodes { get; set; }
        [NonPublicData]
        public List<StockChange> StockChanges { get; set; }
        [NonPublicData]
        public List<ProductPrice> Prices { get; set; }

        public decimal Price { get; set; }
        public int SnackPoints { get; set; }
        public List<Sale> Sales { get; set; }
        [ConcurrencyCheck]
        public Guid RowVersion { get; set; } = Guid.NewGuid();

        public decimal? Weight { get; set; }
        public decimal? Carbohydrates { get; set; }
        public decimal? Sugar { get; set; }
        public decimal? Proteins { get; set; }
        public decimal? Fat { get; set; }
        public decimal? KiloCalories { get; set; }
        public decimal? Salt { get; set; }
        public decimal? SaturatedFat { get; set; }


    }
}