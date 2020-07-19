using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DatabaseModel
{
    public class Sale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? UserPaymentBarcodeId { get; set; }
        public UserPaymentBarcode UserPaymentBarcode { get; set; }
        public Guid? ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int SnackPoints { get; set; }
        public decimal Amount { get; set; }
        public Product Product { get; set; }
        public Guid? ProductId { get; set; }
        
    }
}