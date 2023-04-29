using dotnetapp.Context;
using dotnetapp.Controllers;
using dotnetapp.Cores.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Cores
{
    public class User : IUser
    {
     
        private readonly ILogger logger;

        private readonly LifeDbContext lifeDbContext;
        private ResponseModel response3;

        public User(LifeDbContext lifeDbContext, ILogger<User> logger)
        {
            this.lifeDbContext = lifeDbContext;
            this.logger = logger;
        }
        public async Task<UserModel> Delete(string username)
        { 
            try
            {
                logger.LogInformation("calling database to Delete the User");
                var response2 = await lifeDbContext.userTable.FindAsync(username);
                if (response2 != null)
                {
                    lifeDbContext.userTable.Remove(response2);
                    await lifeDbContext.SaveChangesAsync();
                    return response2;
                }
                else
                { 
                    return null;
                }
            }
            catch (Exception ex) 
            {
                logger.LogError("Error occured while Deleting user data from databse", ex);
                throw ex;
            }
            
        }
         
        public  async Task <IEnumerable<UserModel>> GetAll()
        {
            var res = await lifeDbContext.userTable.ToListAsync();
            return res;
        }

        public async Task <UserModel> Update(UserModel usermodel)
        {
            try
            {
                logger.LogInformation("calling database tp Update the Exiting User");
                var response3 = await lifeDbContext.userTable.FindAsync(usermodel.Username);
                if (response3 != null)
                {
                    response3.Username = usermodel.Username;
                    response3.Password = usermodel.Password;
                   response3.Email = usermodel.Email;
                    response3.MobileNumber = usermodel.MobileNumber;
                    response3.UserRole = usermodel.UserRole;
                    lifeDbContext.userTable.Update(response3);
                    await lifeDbContext.SaveChangesAsync();
                    return response3;
                }
                else
                {
                    return null;
                }
            
            }
            catch(Exception ex) 
            {
                logger.LogError("Error Occured While Updating User Data To The Database", ex);
                throw;
             }
            
        }

        
        }
    }

