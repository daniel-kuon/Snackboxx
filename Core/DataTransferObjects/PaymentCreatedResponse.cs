using Core.DatabaseModel;

namespace Core.DataTransferObjects
{
    public class PaymentCreatedResponse
    {
        public Payment Payment { get; set; }
        public decimal OpenAmount { get; set; }
        public PaymentCreatedResponse(Payment payment, decimal openAmount)
        {
            Payment = payment;
            OpenAmount = openAmount;
        }
    }
}