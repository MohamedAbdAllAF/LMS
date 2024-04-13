using LMS.Models;
using LMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    internal class FeesController
    {
        LMSContext context = new LMSContext();
        AdminLogController log = new AdminLogController();
        ExceptionHandler errHandler = new ExceptionHandler();
        public async Task<bool> AddNewFee(int adminId,Fee fee)
        {
            try
            {
                context.Fees.Add(fee);
                await context.SaveChangesAsync();
                var id = await context.Fees.MaxAsync(fe => fe.Id);
                log.AddLog(adminId, "Fees", "N/A", id, "قام بإضافة الأتعاب");
                return true;
            }catch (Exception ex)
            {
                errHandler.AddExeption(ex, "FeesController", "AddNewFee", DateTime.Now);
                return false;
            }
        }

        public async Task<bool> DeleteFee(int feeId)
        {
            try
            {
                var fee = context.Fees.FirstOrDefault(fe => fe.Id == feeId);
                context.Fees.Remove(fee);
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                errHandler.AddExeption(ex, "FeesController", "DeleteFee", DateTime.Now);
                return false;
            }
        }

        public async Task<List<FeesVM>> GetFees(int licenseId)
        {
            List<FeesVM> result = new List<FeesVM>();

            var fees = await context.Fees.Where(f => f.LicenseId == licenseId).ToListAsync();

            foreach (var fee in fees)
            {
                FeesVM item = new FeesVM
                {
                    FeeId = fee.Id,
                    Amount = fee.Amount,
                    CreatedOn = new DateTime(fee.CreatedOn.Year,fee.CreatedOn.Month,fee.CreatedOn.Day)
                };
                result.Add(item);
            }
            return result;
        }

        public decimal MonthlyIncome(DateTime today)
        {
            var fees = context.Fees.Where(f=>f.CreatedOn.Month == today.Month).ToList();
            decimal result = 0;
            foreach (var fee in fees)
            {
                result += fee.Amount;
            }
            return result;
        }
    }
}
