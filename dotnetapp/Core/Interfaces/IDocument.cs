using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Core.Interfaces
{
    public interface IDocument
    {
       Task<IActionResult> Upload([FromForm] FileUploadModel model);
    }
}
