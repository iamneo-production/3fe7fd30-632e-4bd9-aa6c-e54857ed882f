using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace dotnetapp.Core.Interfaces
{
    public interface IDocument
    {
       Task<bool> Upload([FromForm] FileUploadModel model);
    }
}
