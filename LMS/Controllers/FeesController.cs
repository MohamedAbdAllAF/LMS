using LMS.Models;
using LMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    internal class FeesController
    {
        LMSContext context = new LMSContext();
        AdminLogController log = new AdminLogController();
        ExceptionHandler errHandler = new ExceptionHandler();
        public bool AddNewFee(int adminId,Fee fee)
        {
            try
            {
                context.Fees.Add(fee);
                context.SaveChanges();
                var id = context.Fees.Max(fe => fe.Id);
                log.AddLog(adminId, "Fees", "N/A", id, "قام بإضافة الأتعاب");
                return true;
            }catch (Exception ex)
            {
                errHandler.AddExeption(ex, "FeesController", "AddNewFee", DateTime.Now);
                return false;
            }
        }

        public bool DeleteFee(int feeId)
        {
            try
            {
                var fee = context.Fees.FirstOrDefault(fe => fe.Id == feeId);
                context.Fees.Remove(fee);
                context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                errHandler.AddExeption(ex, "FeesController", "DeleteFee", DateTime.Now);
                return false;
            }
        }

        public List<FeesVM> GetFees(int licenseId)
        {
            List<FeesVM> result = new List<FeesVM>();

            var fees = context.Fees.Where(f => f.LicenseId == licenseId).ToList();

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
    }
}
