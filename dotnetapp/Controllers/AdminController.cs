using dotnetapp.Context;
using dotnetapp.Core;
using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> logger;
        private IAdmin context;
               
       
        public AdminController(IAdmin context, ILogger<AdminController> logger)
        {
            this.context = context;
            this.logger = logger;   
        }

        [HttpPost]
        [Route("GeneratePayment")]
        public async Task<ActionResult<ResponseModel>> GeneratePayment(PlanModel planmodel )
        {
            ResponseModel responseModel = null;
            try
            {
                logger.LogInformation("Calling GeneratePayment Method");
                if (planmodel != null)
                {
                    responseModel = new ResponseModel();
                    var res = await context.GeneratePayment(planmodel);//response
                    if (res != null)
                    {
                        responseModel = new ResponseModel();
                        responseModel.response = new
                        {


                            payment = res
                           
                            
                        };
                        responseModel.Status = true;
                        responseModel.Message = "Success";
                        return responseModel;
                    }
                    else
                    {
                        responseModel = new ResponseModel();
                        responseModel.Status = false;
                        responseModel.Message = "Failure";
                        responseModel.ErrorMessage = "Data NotFound";
                        return responseModel;
                    }
                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.Status = false;
                    responseModel.Message = "Failure";
                    responseModel.ErrorMessage = "Data NotFound";
                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"An Exception has occcured while running program", ex);
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.Message = "Failure";
                responseModel.ErrorMessage = ex.Message;
                return responseModel;
            }

        }

    

        
        [HttpPut]
         [Route("UpdatePayment")]
        public async Task<ActionResult<ResponseModel>>UpdatePayment(List<PaymentModel> paymentSchedule, decimal newPaymentAmount,int id )
        {
            ResponseModel responseModel = null;
            try
            {
                logger.LogInformation("Calling UpdatePayment Method");
                var res = await context.UpdatePayment(paymentSchedule, newPaymentAmount, id);
                
                    if (res != null)
                    {
                        responseModel = new ResponseModel();
                    responseModel = new ResponseModel();
                    responseModel.response = new
                    {


                        payment = res


                    };
                    responseModel.Status = true;
                        responseModel.Message = "Success";
                        return responseModel;
                    }
                    else
                    {
                        responseModel = new ResponseModel();
                        responseModel.Status = false;
                        responseModel.Message = "Failure";
                        responseModel.ErrorMessage = "Data NotFound";
                        return responseModel;
                    }
                }
               
            
            catch (Exception ex)
            {
                logger.LogError($"An Exception has occcured while running program with message {ex.Message}");
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.Message = "Failure";
                responseModel.ErrorMessage = "Invalid Data";
                return responseModel;
            }

        }
    


        [HttpDelete]
        [Route("DeletePayment/{id}")]

        public async Task<ActionResult<ResponseModel>> DeletePayment (int id)
        {
            ResponseModel responseModel = null;
            try
            {
                logger.LogInformation("Calling DeletePayment Method");
                var res =await context.DeletePayment(id);
                
                if (id != 0)
                {
                    responseModel = new ResponseModel();
                    responseModel.response = new
                    {
                        res.PaymentDate,
                        res.PaymentAmount,
                        
                        message = "Deleted successfully",
                    };
                    responseModel.Status = true;
                    responseModel.Message = "Deleted Successfully";
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
            catch (Exception ex)
            {
                logger.LogError($"An Exception has occcured while running program with message {ex.Message}");
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.ErrorMessage = "Failed";
                return responseModel;
            }

        }


        [HttpPut]
        [Route("UpdatePolicy")]
        public async Task<ActionResult<ResponseModel>> UpdatePolicy(int id, PolicyModel policyModel)
        {
            {
                ResponseModel responseModel = null;
                try
                {
                    logger.LogInformation("Calling UpdatePolicy Method");
                    if (policyModel != null)
                    {
                        responseModel = new ResponseModel();
                        var res = await context.Update(id, policyModel);
                        if (res != null)
                        {
                            responseModel = new ResponseModel();
                            responseModel.response = new
                            {
                                res.ApplicantName,
                                res.PolicyType,
                                res.ApplicantAddress,
                                res.ApplicantMobile,
                                res.ApplicantEmail,
                                res.ApplicantAadhaar,
                                res.ApplicantPan,
                                res.ApplicantSalary,
                                message = "Updated successfully",
                            };
                            responseModel.Status = true;
                            responseModel.Message = "Success";
                            return responseModel;
                        }
                        else
                        {
                            responseModel = new ResponseModel();
                            responseModel.Status = false;
                            responseModel.Message = "Failure";
                            responseModel.ErrorMessage = "Data NotFound";
                            return responseModel;
                        }
                    }
                    else
                    {
                        responseModel = new ResponseModel();
                        responseModel.Status = false;
                        responseModel.Message = "Failure";
                        responseModel.ErrorMessage = "Data NotFound";
                        return responseModel;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError($"An Exception has occcured while running program with message {ex.Message}");
                    responseModel = new ResponseModel();
                    responseModel.Status = false;
                    responseModel.Message = "Failure";
                    responseModel.ErrorMessage = "Invalid Data";
                    return responseModel;
                }

            }
        }

        [HttpDelete]
        [Route("DeletePolicy")]
        public async Task<ActionResult<ResponseModel>> DeletePolicy(int id)
        {
            ResponseModel responseModel = null;
            try
            {
                logger.LogInformation("Calling DeletePolicy Method");
                var res = await context.Delete(id);
                if (id != 0)
                {
                    responseModel = new ResponseModel();
                    responseModel.response = new
                    {
                        res.ApplicantName,
                        res.PolicyType,
                        res.ApplicantAddress,
                        res.ApplicantMobile,
                        res.ApplicantEmail,
                        res.ApplicantAadhaar,
                        res.ApplicantPan,
                        res.ApplicantSalary,
                       
                        message = "Deleted successfully",
                 };
                    responseModel.Status = true;
                    responseModel.Message = "Deleted Successfully";
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
            catch (Exception ex)
            {
                logger.LogError($"An Exception has occcured while running program with message {ex.Message}");
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.ErrorMessage = "Failed";
                return responseModel;
            }
        }




        }
}
