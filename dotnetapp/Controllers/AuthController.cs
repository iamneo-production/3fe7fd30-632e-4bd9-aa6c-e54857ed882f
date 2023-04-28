using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize]
    public class AuthController : Controller
    {
        private readonly IAuth auth;

      
        public  AuthController(IAuth auth)
        {
            this.auth = auth;
            
        }
        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<ResponseModel> RegisterUser([FromBody] UserModel userModel)
        {
            try
            {
                if (userModel != null)
                {
                    var response = await auth.RegisterUser(userModel);
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "Send proper Request with proper input";
                    response.Status = true;
                    return response;
                }

            }
            catch (System.Exception ex)
            {

                ResponseModel response = new ResponseModel();
                response.ErrorMessage = "Send proper Request with proper input";
                response.Status = false;
                response.ErrorMessage = ex.Message;
                return response;
            }
        }


        [HttpPost]
        [Route("Token")]
        public ResponseModel GenerateToken([FromBody] LoginModel loginModel)
        {
            ResponseModel response = null;
            try
            {
                if (loginModel != null)
                {
                    if (!loginModel.Email.IsNullOrEmpty() && !loginModel.Password.IsNullOrEmpty())
                    {
                        response = auth.GenerateToken(loginModel);

                        return response;

                    }
                    else
                    {
                        response = new ResponseModel();
                        response.Message = "UserName and Password";
                        response.Status = true;
                        return response;
                    }
                }
                else
                {
                    response = new ResponseModel();
                    response.Message = "Send proper data in request";
                    response.Status = true;
                    return response;
                }
            }
            catch (System.Exception ex)
            {

                response = new ResponseModel();
                response.Message = "Opps !";
                response.ErrorMessage = ex.Message;
                response.Status = false;
                return response;
            }
        }

        
        
    
    }
}
