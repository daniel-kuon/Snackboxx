namespace Core.DatabaseModel
{
    public class Correction : StockChange
    {
        public int? ShelfAmount { get; set; }
        public int? StockAmount { get; set; }
    }
}