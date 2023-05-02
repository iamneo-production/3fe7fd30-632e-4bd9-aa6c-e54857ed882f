using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
namespace dotnetapp.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser User;
        public UserController(IUser user)
        {
            this.User = user;
        }
        [HttpGet]
        [Route("Read")]
       
            public IEnumerable<UserModel> GetAll()
            {
            try
            {
                return User.GetAll();
            }
            catch
            {
                throw;
            }
            }

        /*[HttpPost]
        [Route("Create")]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (user != null)
                {
                    var result = User.Create(user);
                    return Ok(result);
                }
                return BadRequest();
            }

            
            catch{
                throw;
            }
        }*/

    

    [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult>Delete(string username)
        {
            try
            {
                if (username != null)
                {
                    var resopnse =  await User.Delete(username);
                    return Ok(resopnse);
                }
                return BadRequest();
            }
            catch(Exception ex) 
            {
                throw ex;
            }
           
        }
        [HttpPut]
        [Route("Update")]
        public  async Task <IActionResult> Update(UserModel model) 
        {

            try
            {
                var response  = await User.Update(model);
                return Ok(response);
            }
            catch (Exception ex) 
            {
                throw ex;
            
            }
            
            
           
        
        }

    }
}
