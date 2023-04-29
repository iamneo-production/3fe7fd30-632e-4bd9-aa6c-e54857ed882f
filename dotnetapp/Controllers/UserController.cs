using dotnetapp.Context;
using dotnetapp.Cores;
using dotnetapp.Cores.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
namespace dotnetapp.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser User;
        private readonly ILogger<UserController> logger;
        public UserController(IUser user, ILogger<UserController> logger)
        {
            this.User = user;
            this.logger = logger;
        }
        [HttpGet]
        [Route("Read")]
      
        public async Task<ActionResult<ResponseModel>> GetUser()
        {
            try
            {
                logger.LogInformation("Calling GetUser Method");

                var end = await User.GetAll();
                ResponseModel responseModel = new ResponseModel();
                responseModel.Response = new
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
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<ResponseModel>> Delete(string username)
        {
            ResponseModel responseModel = null;
            try
            {
                logger.LogInformation("calling DeleteUser Method");
                var res = await User.Delete(username);
                if (username != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Response = new
                    {
                        res.Email,
                        res.Username,
                        res.MobileNumber,
                        res.UserRole,
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
                logger.LogError($"An Exception has occured while running program with message{ex.Message}");
                responseModel = new ResponseModel();
                responseModel.Status = false;
                responseModel.ErrorMessage = "Failed";
                return responseModel;
            }

        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<ResponseModel>> Update(UserModel model)
        {
            ResponseModel responseModel = null;
            try
            {
                logger.LogInformation("Calling UpdateUser Method");
                if (User != null)
                {
                    responseModel = new ResponseModel();
                    
                    var res = await User.Update(model);
                    if (res != null)
                    {
                        responseModel = new ResponseModel();
                        responseModel.Response = new
                        {
                            res.Email,
                            res.Username,
                            res.MobileNumber,
                            res.UserRole,
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
}


    
           