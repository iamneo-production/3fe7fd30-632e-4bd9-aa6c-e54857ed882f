﻿using dotnetapp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace dotnetapp.Core.Interfaces
{
    public interface IPlan
    {
        Task<IEnumerable<PlanModel>> GetPlan();
        Task<PlanModel> AddPlan(PlanModel planModel);
        Task<PlanModel> RemovePlan(int id);
        Task<PlanModel> EditPlan(int id, PlanModel planModel);

    }
}
