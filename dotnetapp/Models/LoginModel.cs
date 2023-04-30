using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace dotnetapp.Models
{
    
    public class LoginModel 
    {
        [Key]
        public string Email { get; set; }
        public string? Password { get; set; }
    }
    
}
