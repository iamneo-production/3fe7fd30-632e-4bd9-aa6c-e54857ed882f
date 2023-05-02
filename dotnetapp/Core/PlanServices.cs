using dotnetapp.Context;
using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace dotnetapp.Core
{
    public class PlanServices : IPlan
    {

        private readonly LifeDbContext Context;

        public PlanServices(LifeDbContext lifeDbContext)
        {
           this.Context = lifeDbContext;
        }

        public async Task<PlanModel> AddPlan(PlanModel planModel)
        {
            try
            {

                if (planModel != null)
                {
                    await Context.planTable.AddAsync(planModel);
                    await Context.SaveChangesAsync();
                    return planModel;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PlanModel> EditPlan(int id, PlanModel plan)
        {
            try
            {
                var response3 = await Context.planTable.FindAsync(id);
                {
                    if (response3 != null)
                    {
                        response3.InterestRate = plan.InterestRate;
                        response3.PolicyName = plan.PolicyName;
                        response3.ApplicableAge = plan.ApplicableAge;
                        response3.years = plan.years;
                        response3.claimamount = plan.claimamount;
                        Context.planTable.Update(response3);
                        await Context.SaveChangesAsync();
                        return response3;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                 throw;
            }
        }

        public async Task<IEnumerable<PlanModel>> GetPlan()
        {
            {
                var res = await Context.planTable.ToListAsync();
                return res;
            }
        }

        public async Task<PlanModel> RemovePlan(int id)
        {
            try
            {
                var response = await Context.planTable.FindAsync(id);
                if (response != null)
                {
                    Context.planTable.Remove(response);
                    await Context.SaveChangesAsync();
                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                  throw ex;
            }


        }
    }
}
