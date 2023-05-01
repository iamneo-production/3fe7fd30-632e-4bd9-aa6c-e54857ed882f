using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;

namespace dotnetapp.Models
{
    public class FileUploadModel
    {
        public IFormFile File { get; set; }
    }
}
