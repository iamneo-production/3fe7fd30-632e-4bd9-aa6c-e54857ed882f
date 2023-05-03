using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class PlanModel
    {
        [Key]
        public int PlanId { get; set; }
        
        public string? PolicyName { get;set; }
        [Required]
        public int ApplicableAge { get; set; }

        public int? years { get; set; }

        public decimal? claimamount { get; set; }

        public int InterestRate { get; set; }

        
    }
}
