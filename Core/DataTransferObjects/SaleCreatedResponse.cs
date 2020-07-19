using Core.DatabaseModel;

namespace Core.DataTransferObjects
{
    public class SaleCreatedResponse
    {
        public Sale Sale { get; set; }
        public decimal OpenAmount { get; set; }

        public SaleCreatedResponse(Sale sale, decimal openAmount)
        {
            Sale = sale;
            OpenAmount = openAmount;
        }
    }
}