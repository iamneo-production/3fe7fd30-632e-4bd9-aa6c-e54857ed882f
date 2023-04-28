using dotnetapp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace dotnetapp.Core.Interface
{
    public interface IAdmin
    {
        Task<PaymentModel> DeletePayment(int id);
        Task<List<PaymentModel>> GeneratePayment(PlanModel planmodel);


        Task<PaymentModel> UpdatePayment(List<PaymentModel> paymentSchedule, decimal newPaymentAmount, int id);

        Task<PolicyModel> Delete(int id);
        Task<PolicyModel> Update(int id, PolicyModel policyModel);


    }
}
