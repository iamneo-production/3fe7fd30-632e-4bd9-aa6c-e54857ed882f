using dotnetapp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace dotnetapp.Cores.Interfaces
{
    public interface IUser
    {
         Task <IEnumerable<UserModel>> GetAll();
      //  public bool Create(UserModel userModel);
        Task<UserModel> Update(UserModel userModel);
        Task<UserModel> Delete(string username);

    }
}
