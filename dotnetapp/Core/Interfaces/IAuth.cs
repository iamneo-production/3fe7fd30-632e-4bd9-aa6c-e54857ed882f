﻿using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace dotnetapp.Core.Interfaces
{
    public interface IAuth
    {
        Task<ResponseModel> RegisterUser(UserModel userModel);
        ResponseModel GenerateToken(LoginModel loginModel);

    }
}
