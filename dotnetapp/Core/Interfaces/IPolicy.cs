﻿using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Cores.Interfaces
{
    public interface IPolicy
    {
        Task<IEnumerable<PolicyModel>> GetAll();
        Task<PolicyModel> Create(PolicyModel policyModel);
        Task<PolicyModel> Delete(int id);
        Task<PolicyModel> Update(int id, PolicyModel policyModel);
        
             //Interfaces will not have access modifiers
            
        }
}
