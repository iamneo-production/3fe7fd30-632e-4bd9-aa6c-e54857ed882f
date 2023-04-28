using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;
namespace dotnetapp.Models
{
   
    public class DocumentModel
    {
        [Key]
        public int? DocumentId { get; set; }
        public string? DocumentType { get; set; }
        public Byte[]? DocumentUpload { get; set; }
        
    }
}
