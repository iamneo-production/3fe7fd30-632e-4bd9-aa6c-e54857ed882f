using dotnetapp.Context;
using dotnetapp.Core;
using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] 
    public class PolicyController : ControllerBase
    {

        private readonly IPolicy ipolicy;
        private readonly ILogger<PolicyController> logger;
        public PolicyController(IPolicy ipolicy, ILogger<PolicyController> logger)
        {
            this.ipolicy = ipolicy;
            this.logger = logger;
        }
        [HttpGet]
        [Route("Read")]
        public async Task<ActionResult<ResponseModel>>GetAll()
        {
          
            try
            {
                logger.LogInformation("calling");
                var res = await ipolicy.GetAll();
                                           //Check the output respone for null & then return the values
                ResponseModel responseModel = new ResponseModel();
                responseModel.response = new
                {
                    policyTable = res
                };
                responseModel.Status = true;
                return responseModel;
            }
            catch(Exception ex)
            {
                logger.LogError($"error occured");
                throw ex;
            }
        }
        [HttpPost]
        [Route("Add")]//Change the route
        public async Task<ActionResult<ResponseModel>> Create(PolicyModel policyModel)
        {
            ResponseModel responseModel = null;
            try
            {
                logger.LogInformation("calling");
                if (ipolicy != null)
                {
                    var result = await ipolicy.Create(policyModel);
                    if (result != null)
                    {
                        responseModel = new ResponseModel();
                        responseModel.response = new
                        {
                            result.ApplicantName,
                            result.PolicyType,
                            result.ApplicantAddress,
                            result.ApplicantMobile,
                            result.ApplicantEmail,
                            result.ApplicantAadhaar,
                            result.ApplicantPan,
                            result.ApplicantSalary,
                            Message = "Created Successfully",

                        };
                        responseModel.Status = true;
                        responseModel.Message = "Success";
                        return responseModel;
                     }
                                     
                }
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.ErrorMessage = "Failed";
                return responseModel;
            }
            catch(Exception ex)  
            {
                logger.LogError($"error occured");
                throw ex;
            }
           
        }
        [HttpPut]
        [Route("UpdatePolicy")]
        public async Task<ActionResult<ResponseModel>> Update(int id, PolicyModel policyModel)
        {
            ResponseModel responseModel = null;
            try
            {
                logger.LogInformation("calling");
                if (policyModel != null)
                {
                    responseModel = new ResponseModel();
                    var result = await ipolicy.Update(id, policyModel);
                    if (result != null)
                    {
                        responseModel = new ResponseModel();
                        responseModel.response = new
                        {
                            result.ApplicantName,
                            result.PolicyType,
                            result.ApplicantAddress,
                            result.ApplicantMobile,
                            result.ApplicantEmail,
                            result.ApplicantAadhaar,
                            result.ApplicantPan,
                            result.ApplicantSalary,
                            Message = "Created Successfully",
                        };
                        responseModel.Status = true;
                        responseModel.Message = "Success";
                        return responseModel;
                    }
                    else
                    {
                        responseModel = new ResponseModel();
                        responseModel.Status = false;
                        responseModel.ErrorMessage = "Failed";
                        return responseModel;
                    }
                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status = false;
                    responseModel.ErrorMessage = "Failed";
                    return responseModel;
                }
                }
            catch (Exception ex)
            {
                logger.LogError($"error occured");
                throw ex;
            }


        }
        [HttpDelete]
        [Route("DeletePolicy")] //Follow the same comments given above
        public async Task< ActionResult<ResponseModel>> Delete(int id)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                logger.LogInformation("calling");
                var result = await ipolicy.Delete(id);
                if (id != 0)
                {
                    responseModel = new ResponseModel();
                    responseModel.response = new
                    {
                        result.ApplicantName,
                        result.PolicyType,
                        result.ApplicantAddress,
                        result.ApplicantMobile,
                        result.ApplicantEmail,
                        result.ApplicantAadhaar,
                        result.ApplicantPan,
                        result.ApplicantSalary,
                        Message = "Created Successfully",

                    };
                    responseModel.Status = true;
                    responseModel.Message = "Success";
                    return responseModel;
                }
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.ErrorMessage = "Failed";
                return responseModel;
            }
            catch(Exception ex)
            {
                logger.LogError($"error occured");
                throw ex;
            }
            
        }
    }
}
