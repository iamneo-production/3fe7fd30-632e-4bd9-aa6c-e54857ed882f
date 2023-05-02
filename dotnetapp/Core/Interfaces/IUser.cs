using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace dotnetapp.Core.Interfaces
{
    public interface IUser
    {
        IEnumerable<UserModel> GetAll();
      //  public bool Create(UserModel userModel);
        Task<ResponseModel> Update(UserModel userModel);
        Task<ResponseModel> Delete(string username);

    }
}
