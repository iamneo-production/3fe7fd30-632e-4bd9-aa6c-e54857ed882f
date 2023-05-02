using dotnetapp.Context;
using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Linq;
using System;

namespace dotnetapp.Core
{
    public class Auth : IAuth
    {
        private readonly LifeDbContext lifeDb;
       private readonly IConfiguration configuration;
       private readonly ILogger<Auth> logger;
        public Auth(LifeDbContext lifeDb, IConfiguration configuration)
        {
            this.lifeDb = lifeDb;
            this.configuration = configuration;
            
        }
        public ResponseModel GenerateToken(LoginModel loginModel)
        {
            try
            {
                var role= lifeDb.userTable.Where(x=>x.Email==loginModel.Email).Select(y=>y.UserRole).First();
                var userExists = lifeDb.userTable.FirstOrDefault(x => x.Email.ToLower() == loginModel.Email.ToLower() && x.Password.ToLower() == loginModel.Password.ToLower());
                if (userExists != null)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    var claims = new[]
                        {
                        new Claim(ClaimTypes.Name,loginModel.Email),
                        //new Claim(ClaimTypes.Role, userExists?.UserRole)
                         new Claim("role" , role)
                    };

                    var token = new JwtSecurityToken(null,null, claims, expires: DateTime.Now.AddDays(1), signingCredentials: credentials);

                    var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);


                    ResponseModel responseModel = new ResponseModel();
                    responseModel.Message = generatedToken.ToString();
                    responseModel.Status = true;
                    return responseModel;
                }
                ResponseModel response = new ResponseModel();
                response.ErrorMessage = $"No user found with username{loginModel.Email}";
                response.Status = true;
                return response;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ResponseModel> RegisterUser(UserModel userModel)
        {
            ResponseModel responseModel = null;
            try
            {
                var response = await lifeDb.userTable.AddAsync(userModel);
                await lifeDb.SaveChangesAsync();
                if (response != null)
                {
                    responseModel = new ResponseModel();
                    responseModel.Message = "User registered";
                    responseModel.Status = true;
                    return responseModel;
                }
                else
                {
                    responseModel = new ResponseModel();
                    responseModel.ErrorMessage = "User registration failled";
                    responseModel.Status = false;
                    return responseModel;
                }
            }
            catch (Exception ex)
            {
                

                throw ex;
            }
        }
    }
}


