using dotnetapp.Context;
using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace dotnetapp.Core
{
    public class User : IUser
    {
        private readonly LifeDbContext lifeDbContext;
        public User(LifeDbContext lifeDbContext)
        {
            this.lifeDbContext = lifeDbContext;
        }
        /*public bool Create(UserModel userModel)
        {
            try
            {
                lifeDbContext.userTable.Add(userModel);
                lifeDbContext.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }*/
        public async Task<ResponseModel> Delete(string username)
        {
            try
            {
                if (username != null)
                {
                    var a = lifeDbContext.userTable.Find(username);
                    lifeDbContext.userTable.Remove(a);
                    await lifeDbContext.SaveChangesAsync();
                    ResponseModel response = new ResponseModel();
                    response.Message = "Deleted Successfully";
                    response.Status = true;
                    return response;
                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "Delete Failed";
                    response.Status = false;
                    return response;
                }
            }
            catch
            {
                throw;
            }
        }
         
        public IEnumerable<UserModel> GetAll()
        {
           return  lifeDbContext.userTable.ToList();   
        }

        public async Task <ResponseModel> Update(UserModel usermodel)
        {
            try
            {
                var a = lifeDbContext.userTable.Find(usermodel.Username);
                if (a != null)
                {
                    a.Username = usermodel.Username;
                    a.Password = usermodel.Password;
                    a.Email = usermodel.Email;
                    a.MobileNumber = usermodel.MobileNumber;
                    a.UserRole = usermodel.UserRole;
                    lifeDbContext.userTable.Update(a);
                    await lifeDbContext.SaveChangesAsync();
                    ResponseModel response = new ResponseModel();
                    response.Message = "Updated Successfully";
                    response.Status = true;
                    return response;


                }
                else
                {
                    ResponseModel response = new ResponseModel();
                    response.Message = "Update Failed";
                    response.Status = false;
                    return response;
                }
            
            }
            catch
            {
                throw;
            }

        }
    }
}
