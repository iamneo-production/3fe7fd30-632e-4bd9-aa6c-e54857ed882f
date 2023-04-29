using dotnetapp.Context;
using dotnetapp.Cores;
using dotnetapp.Cores.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
namespace dotnetapp.Cores
{
    public class PolicyCore : IPolicy
    {
        private readonly LifeDbContext lifeDbContext; //Naming convention change
        private readonly ILogger<PolicyCore> logger;
      //  private readonly ResponseModel responseModel;
        public PolicyCore(LifeDbContext lifeDbContext, ILogger<PolicyCore> logger)

        {
            this.lifeDbContext = lifeDbContext;
            this.logger = logger;
            // this.responseModel = responseModel;
        }

        public async Task<PolicyModel> Create(PolicyModel policyModel)
        {
            try
            {
                logger.LogInformation("calling ");
                if (policyModel != null)
                {
                    await lifeDbContext.policyTable.AddAsync(policyModel);
                    await lifeDbContext.SaveChangesAsync();
                    return policyModel;
                }
                return null;//Return response models
            }
            catch(Exception ex) 
            {
                logger.LogError("error occured", ex);
                throw ex;
            }
        }   
            
            public async Task<PolicyModel> Delete(int id)
        {
            try
            {
                logger.LogInformation("calling ");
                var response = lifeDbContext.policyTable.Find(id);
                if (response != null)
                {
                    lifeDbContext.policyTable.Remove(response);
                      await lifeDbContext.SaveChangesAsync();
                     return response;
                }
                return null;

            }
            catch(Exception ex) {
                logger.LogError("error occured", ex);
                throw ex;
            }

        }

        public async Task<IEnumerable<PolicyModel>> GetAll()
        {
            try
            {
                
                var model = await lifeDbContext.policyTable.ToListAsync();
                return model;
            }
            catch(Exception ) 
            {
                throw;              //Handle exceptions properly
            }
        }



        public async Task<PolicyModel> Update(int id, PolicyModel policyModel)
        {
            try {
                logger.LogInformation("calling ");
                var response = await lifeDbContext.policyTable.FindAsync(id);
                if (response != null)
                {
                    response.ApplicantName = policyModel.ApplicantName;
                    response.PolicyType = policyModel.PolicyType;
                    response.ApplicantAddress = policyModel.ApplicantAddress;
                    response.ApplicantMobile = policyModel.ApplicantMobile;
                    response.ApplicantEmail = policyModel.ApplicantEmail;
                    response.ApplicantAadhaar = policyModel.ApplicantAadhaar;
                    response.ApplicantPan = policyModel.ApplicantPan;
                    response.ApplicantSalary = policyModel.ApplicantSalary;


                    lifeDbContext.policyTable.Update(response);
                   await lifeDbContext.SaveChangesAsync();
                    return response;
                }
              
                return null;

            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}