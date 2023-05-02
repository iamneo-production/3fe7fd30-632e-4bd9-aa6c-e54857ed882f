using dotnetapp.Core;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using System.Runtime.InteropServices;

using System.Threading.Tasks;

using System;

using Microsoft.Extensions.Logging;




namespace dotnetapp.Controllers

{



    [ApiController]

    [Route("api/[controller]")]

    public class DocumentController : Controller

    {

        private readonly DocumentServices documentService;

        private readonly ILogger<DocumentController> logger;

        public DocumentController(DocumentServices documentService, ILogger<DocumentController> logger)

        {

            this.documentService = documentService;

            this.logger = logger;

        }




        [HttpPost]

        [Route("document")]






        public async Task<ActionResult<ResponseModel>> Upload([FromForm] FileUploadModel model)

        {

            ResponseModel docUploadResponse = null;

            try

            {

                logger.LogInformation("calling Document Upload Method");

                if (model != null)

                {

                    var uploadResponse = await documentService.Upload(model);

                    if (uploadResponse != null)

                    {

                        docUploadResponse = new ResponseModel();

                        docUploadResponse.response = new
                        {

                            docResponse = "Document uploaded successfully"

                        };

                        docUploadResponse.Status = true;

                        docUploadResponse.Message = "Success";

                        return docUploadResponse;

                    }

                    else

                    {

                        docUploadResponse = new ResponseModel();



                        docUploadResponse.ErrorMessage = "Document not uploaded";

                        docUploadResponse.Status = false;

                        docUploadResponse.Message = "fail";

                        return docUploadResponse;

                    }



                }

                else
                {



                    docUploadResponse = new ResponseModel();



                    docUploadResponse.ErrorMessage = "Document not uploaded";

                    docUploadResponse.Status = false;

                    docUploadResponse.Message = "fail";

                    return docUploadResponse;

                }





            }

            catch (Exception ex)

            {

                docUploadResponse = new ResponseModel();



                docUploadResponse.ErrorMessage = "Document not uploaded";

                docUploadResponse.Status = false;

                docUploadResponse.Message = "fail";

                return docUploadResponse;

            }

        }

    }

}






