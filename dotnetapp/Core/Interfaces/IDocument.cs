﻿using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace dotnetapp.Core.Interfaces
{
    public interface IDocument
    {
       Task<IActionResult> Upload([FromForm] FileUploadModel model);
    }
}