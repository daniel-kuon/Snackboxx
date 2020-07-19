using System;

namespace Core.DataTransferObjects
{
    public class UserOverview
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Mail { get; set; }
        public bool ProductBarcodesEnabled { get; set; }
        public decimal OpenAmount { get; set; }
        public DateTime? LastSale { get; set; }
        public bool IsInOffice { get; set; }
        public bool TimeCodeEnabled { get; set; }
        
        
    }
}