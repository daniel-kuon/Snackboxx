using System;

namespace Core.DataTransferObjects
{
    public class SaleSummary
    {
        public SaleSummaryMode Mode { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}