using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    
    public class AdminModel
    {
        
        public string? Password { get; set; }
        [Key]
        public string? Email { get; set; }
       
        public string? MobileNumber { get; set; }
        
        public string? UserRole { get; set; }
    }
}
