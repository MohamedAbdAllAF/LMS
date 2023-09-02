using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    internal class ValidityStatmentController
    {
        LMSContext context= new LMSContext();
        ExceptionHandler errHandle = new ExceptionHandler();
        AdminLogController log = new AdminLogController();

        public int AddNewValidityStatment(int adminId , ValidityStatment dataObj)
        {   
            try
            {
                context.validityStatments.Add(dataObj);
                context.SaveChanges();
                var id = context.validityStatments.Max(x => x.Id);

                if (dataObj.EntryDate == null && dataObj.InitialSupplyDate == null &&
                    dataObj.ValidatySupplyDate == null && dataObj.ReceiveDate == null)
                {
                    log.AddLog(adminId, "ValidityStatments", "N/A", id, "Initializing The record");
                }
                else
                {
                    if(dataObj.EntryDate != null)
                        log.AddLog(adminId, "ValidityStatments", "EntryDate", id, "قام بإضافة تاريخ الدخول لبيان الصلاحية");
                    if(dataObj.InitialSupplyDate != null)
                        log.AddLog(adminId, "ValidityStatments", "InitialSupplyDate", id, "قام بإضافة تاريخ التوريد الأولي لبيان الصلاحية");
                    if(dataObj.ValidatySupplyDate != null)
                        log.AddLog(adminId, "ValidityStatments", "ValidatySupplyDate", id, "قام بإضافة تاريخ توريد بيان الصلاحية");
                    if(dataObj.ReceiveDate != null)
                        log.AddLog(adminId, "ValidityStatments", "ReceiveDate", id, "قام بإضافة تاريخ الاستلام لبيان الصلاحية");
                }
                return Convert.ToInt32(id);
            }
            catch (Exception ex)
            {
                errHandle.AddExeption(ex, "ValidityStatmentController", "AddNewValidityStatment", DateTime.Now);
                return -1;
            }
        }
    }
}
