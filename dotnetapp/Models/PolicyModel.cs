using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class PolicyModel
    {
        [Key]
        public int PolicyId { get; set; }
        [Required(ErrorMessage = "ApplicantName is required")]
        public string ApplicantName { get; set; }
        [Required]
        public string? PolicyType { get; set; } 
        [Required(ErrorMessage = "ApplicantAdress is required")]
        public string? ApplicantAddress { get; set; }

        [Required(ErrorMessage = "ApplicantMobile is required")]
        public string? ApplicantMobile { get; set; }

        [Required(ErrorMessage = "ApplicantEmail is required")]
        public string? ApplicantEmail { get; set; }

        [Required(ErrorMessage = "ApplicantAadhar is required")]
        public string? ApplicantAadhaar { get; set; }

        [Required(ErrorMessage = "ApplicantPan is required")]
        public string? ApplicantPan { get; set; }

        [Required(ErrorMessage = "ApplicantSalary is required")]
        public string? ApplicantSalary { get; set; }
    }
}
