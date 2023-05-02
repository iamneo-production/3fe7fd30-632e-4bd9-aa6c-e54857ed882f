using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;

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
