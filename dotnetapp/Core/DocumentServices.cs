using dotnetapp.Context;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Core
{
    public class DocumentServices
    {
        private readonly LifeDbContext _context;
        public DocumentServices(LifeDbContext _context)
        {
            this._context = _context;
        }
        public async Task<bool> Upload([FromForm] FileUploadModel model)

        {

            if (model.File == null || model.File.Length == 0)
                return false;
            if (model.File.ContentType != "image/jpeg" &&
                model.File.ContentType != "image/png" &&
                model.File.ContentType != "application/pdf")
                return false;

            if (model.File.Length > 2 * 1024 * 1024)
                return false;

            using (var memoryStream = new MemoryStream())
            {
                await model.File.CopyToAsync(memoryStream);
                var fileBytes = memoryStream.ToArray();
                var fileData = new DocumentModel
                {
                    DocumentType = model.File.ContentType,
                    DocumentUpload = fileBytes
                };
                var e=_context.documentTable.Add(fileData);
                await _context.SaveChangesAsync();
            }

            return true;

        }
    }
}
