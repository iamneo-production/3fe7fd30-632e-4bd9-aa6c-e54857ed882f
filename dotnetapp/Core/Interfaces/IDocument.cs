using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
namespace dotnetapp.Core.Interfaces
{
    public interface IDocument
    {
       Task<IActionResult> Upload([FromForm] FileUploadModel model);
    }
}
