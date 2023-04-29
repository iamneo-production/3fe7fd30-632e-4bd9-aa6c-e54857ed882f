using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    
    public class UserModel
    {
        [Key]
        [Required(ErrorMessage ="Username is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])(?!.*\s).*$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        
        public string? Password { get; set; }
        [Required]
      
        public string? Email { get; set; }
        [Required]
        public string? MobileNumber  { get; set; }
        [Required]
        public string? UserRole { get; set; }
    }
}
