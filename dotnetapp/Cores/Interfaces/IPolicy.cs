using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using dotnetapp.Cores.Interfaces;
using System.Threading.Tasks;

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
