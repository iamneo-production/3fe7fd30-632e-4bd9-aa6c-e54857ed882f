using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    
    public class PaymentModel
    {
        [Key]
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
