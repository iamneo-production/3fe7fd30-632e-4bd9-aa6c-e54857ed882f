using dotnetapp.Context;
using dotnetapp.Core.Interfaces;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
namespace dotnetapp.Core
{
    public class AdminServices : IAdmin
    {

        private LifeDbContext _context;

        public AdminServices (LifeDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentModel> DeletePayment(int id)
        {
            var e = _context.paymentTable.Find(id);
            if (e != null)
            {
                _context.paymentTable.Remove(e);
                await _context.SaveChangesAsync();
                return e;
            }
            return null;
        }

        public async Task<List<PaymentModel>> GeneratePayment(PlanModel planmodel)
        
        {

            var monthlyPremium = planmodel.claimamount / planmodel.years + planmodel.claimamount * planmodel.InterestRate / (planmodel.years * 100);

            List<PaymentModel> paymentSchedule = new List<PaymentModel>();

            int months = (int)(planmodel.years * 12);
             for (int i = 1; i <= months; i++)
            {

                PaymentModel payment = new PaymentModel();
                {
                    payment.PaymentDate = DateTime.Today.AddMonths(i);
                    payment.PaymentAmount = (decimal)monthlyPremium;
                };
                 paymentSchedule.Add(payment);
                _context.paymentTable.Add(payment);
                _context.SaveChanges();

            }
            return paymentSchedule;
        }


        [HttpPut("{id}/payments")]

        public async Task<List<PaymentModel>> UpdatePayment(List<PaymentModel> payments, decimal newPaymentAmount, int id)

        {
             foreach (var payment in payments)
            {
                var paymentToUpdate = _context.paymentTable.FirstOrDefault(p => p.PaymentId == id);
                if (paymentToUpdate != null)
                {
                    paymentToUpdate.PaymentAmount = newPaymentAmount;

                }
            }
            await _context.SaveChangesAsync();
            return payments;
        }

        //public async Task<PaymentModel> UpdatePayment(List<PaymentModel> paymentSchedule, decimal newPaymentAmount, int id)
        //{
        //    try
        //    {
        //        var paymentToUpdate = paymentSchedule.FirstOrDefault(p => p.PaymentId == id);
        //        if (paymentToUpdate != null)
        //        {
        //            _context.paymentTable.Update(paymentToUpdate);
        //            await _context.SaveChangesAsync();
        //        }
        //        return paymentToUpdate;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public async Task<PolicyModel> Delete(int id)
        {
            try
            {
                var res = _context.policyTable.Find(id);
                if (res != null)
                {
                    _context.policyTable.Remove(res);
                    await _context.SaveChangesAsync();
                    
                    return res;
                }
                return null;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<PolicyModel> Update(int id, PolicyModel policyModel)
        {
            try
            {
                var res = await _context.policyTable.FindAsync(id);
                if (res != null)
                {
                    res.ApplicantName = policyModel.ApplicantName;
                    res.PolicyType = policyModel.PolicyType;
                    res.ApplicantAddress = policyModel.ApplicantAddress;
                    res.ApplicantMobile = policyModel.ApplicantMobile;
                    res.ApplicantEmail = policyModel.ApplicantEmail;
                    res.ApplicantAadhaar = policyModel.ApplicantAadhaar;
                    res.ApplicantPan = policyModel.ApplicantPan;
                    res.ApplicantSalary = policyModel.ApplicantSalary;


                    _context.policyTable.Update(res);
                    await _context.SaveChangesAsync();
                   
                    return res;
                }
               
                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
