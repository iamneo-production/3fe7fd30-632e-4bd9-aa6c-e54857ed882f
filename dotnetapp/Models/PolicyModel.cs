using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class PolicyModel
    {
        [Key]
        public int PolicyId { get; set; }
        public string? ApplicantName { get; set; }
        public string? PolicyType { get; set; }
        public string? ApplicantAddress { get; set; }
        public string? ApplicantMobile { get; set; }
        public string? ApplicantEmail { get; set; }
        public string? ApplicantAadhaar { get; set; }
        public string? ApplicantPan { get; set; }
        public string? ApplicantSalary { get; set; }
    }
}
