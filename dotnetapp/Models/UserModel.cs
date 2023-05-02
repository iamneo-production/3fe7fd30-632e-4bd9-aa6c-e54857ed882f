﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    
    public class UserModel
    {
        [Key]
        public string Username { get; set; }
        
        public string? Password { get; set; }
      
        public string? Email { get; set; }
        public string? MobileNumber  { get; set; }
        public string? UserRole { get; set; }
    }
}
