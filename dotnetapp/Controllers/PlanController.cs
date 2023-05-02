using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Web.Http.Results;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly ILogger<AdminController> logger;
        private IPlan iplan;


        public PlanController(IPlan iplan, ILogger<AdminController> logger)
        {
            this.iplan = iplan;
            this.logger = logger;
        }
        
            [HttpPost]

            [Route("AddPlan")]

            public async Task<ActionResult<ResponseModel>> AddUser(PlanModel plan)

            {

                ResponseModel responseModel = null;

                try

                {

                    logger.LogInformation("Calling AddPlan Method");

                    if (plan != null)

                    {

                        var result = await iplan.AddPlan(plan);

                        if (result != null)

                        {

                            responseModel = new ResponseModel();

                            responseModel.response = new

                            {

                                result.PolicyName,

                                result.claimamount,

                                result.ApplicableAge,

                                result.years,
                                result.InterestRate,

                                message = "Created successfully",


                            };

                            responseModel.Status = true;

                            responseModel.Message = "SUCCESS";

                            return responseModel;

                        }

                    }

                    responseModel = new ResponseModel();

                    responseModel.Status = false;

                    responseModel.Message = "Failure";

                    responseModel.ErrorMessage = "Invalid data";

                    return responseModel;


                 }

                catch (Exception ex)

                {

                    logger.LogError($"An Exception has occcured while running program with message {ex.Message}");

                    responseModel = new ResponseModel();

                    responseModel.Status = false;

                    responseModel.Message = "Failure";

                    responseModel.ErrorMessage = ex.Message;

                    return responseModel;


                }

            }

            [HttpDelete]

            [Route("DeletePlan")]

            public async Task<ActionResult<ResponseModel>> DeletePlan(int id)

            {

                ResponseModel responseModel = null;

                try

                {

                    logger.LogInformation("Calling DeletePlan Method");

                    var result = await iplan.RemovePlan(id);

                    if (id != 0)

                    {

                        responseModel = new ResponseModel();

                        responseModel.response = new
                        {
                            result.PolicyName,
                            result.claimamount,
                            result.ApplicableAge,

                            result.years,
                            result.InterestRate,

                            
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

            [Route("UpdatePlan")]

            public async Task<ActionResult<ResponseModel>> UpdatePlan(int id, PlanModel plan)

            {

                ResponseModel responseModel = null;

                try

                {

                    logger.LogInformation("Calling UpdateUser Method");

                    if (plan != null)

                    {

                        responseModel = new ResponseModel();

                        var result = await iplan.EditPlan(id, plan);

                        if (result != null)

                        {

                            responseModel = new ResponseModel();

                            responseModel.response = new

                            {

                                result.PolicyName,
                                result.claimamount,
                                result.ApplicableAge,

                                result.years,
                                result.InterestRate,

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



        [HttpGet]

        [Route("ReadAll")]


        public async Task<ActionResult<ResponseModel>> GetPlan()

        {

            try

            {

                logger.LogInformation("Calling GetPlan Method");


                var end = await iplan.GetPlan();

                ResponseModel responseModel = new ResponseModel();

                responseModel.response = new

                {

                    users = end



                };

                responseModel.Status = true;


                return responseModel;

            }

            catch (Exception ex)

            {

                logger.LogError($"An Exception has occcured while running program with message {ex.Message}");

                ResponseModel responseModel = new ResponseModel();

                responseModel.Status = true;

                responseModel.Message = "Success";

                responseModel.ErrorMessage = "Failure";

                return responseModel;





            }





        }







    }

}






               