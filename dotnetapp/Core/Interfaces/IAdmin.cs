using dotnetapp.Models;
using System.Threading.Tasks;

namespace dotnetapp.Core.Interfaces
{
    public interface IAdmin
    {
        Task<PaymentModel> DeletePayment(int id);
        Task<List<PaymentModel>> GeneratePayment(PlanModel planmodel);


        Task<List<PaymentModel>> UpdatePayment(List<PaymentModel> paymentSchedule, decimal newPaymentAmount, int id);

        Task<PolicyModel> Delete(int id);
        Task<PolicyModel> Update(int id, PolicyModel policyModel);


    }
}
