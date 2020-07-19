namespace Core.DatabaseModel
{
    public abstract class Disposal : StockChange
    {
        public int Amount { get; set; }
        public DisposalType Type { get; set; }
    }
}