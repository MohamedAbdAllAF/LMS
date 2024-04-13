using LMS.Models;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    internal class ValidityStatmentController
    {
        LMSContext context= new LMSContext();
        ExceptionHandler errHandle = new ExceptionHandler();
        AdminLogController log = new AdminLogController();

        public async Task<int> AddNewValidityStatment(int adminId , ValidityStatment dataObj)
        {   
            try
            {
                context.validityStatments.Add(dataObj);
                await context.SaveChangesAsync();
                var id = await context.validityStatments.MaxAsync(x => x.Id);

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

        public async Task<int> UpdateValidityStatment(int adminId, ValidityStatment newValidity)
        {
            var oldvalidity = await context.validityStatments.FirstOrDefaultAsync(v=>v.Id == newValidity.Id);
            if (oldvalidity != null)
            {
                if (newValidity.EntryDate == null && newValidity.InitialSupplyDate == null &&
                    newValidity.ValidatySupplyDate == null && newValidity.ReceiveDate == null)
                {
                    return -1;
                }
                else
                {
                    if (newValidity.EntryDate != null && oldvalidity.EntryDate == null)
                    {
                        log.AddLog(adminId, "ValidityStatments", "EntryDate", oldvalidity.Id,
                            "قام بإضافة تاريخ الدخول لبيان الصلاحية");
                        oldvalidity.EntryDate = newValidity.EntryDate;
                    }
                    else if(newValidity.EntryDate != null && oldvalidity.EntryDate != null)
                    {
                        log.AddLog(adminId, "ValidityStatments", "EntryDate", oldvalidity.Id,
                            $"قام بتغيير تاريخ الدخول لبيان الصلاحية من {oldvalidity.EntryDate} الي {newValidity.EntryDate}");
                        oldvalidity.EntryDate = newValidity.EntryDate;
                    }

                    if (newValidity.InitialSupplyDate != null && oldvalidity.InitialSupplyDate == null)
                    {
                        log.AddLog(adminId, "ValidityStatments", "InitialSupplyDate", oldvalidity.Id,
                            "قام بإضافة تاريخ التوريد الأولي لبيان الصلاحية");
                        oldvalidity.InitialSupplyDate = newValidity.InitialSupplyDate;
                    }
                    else if(newValidity.InitialSupplyDate != null && oldvalidity.InitialSupplyDate != null)
                    {
                        log.AddLog(adminId, "ValidityStatments", "InitialSupplyDate", oldvalidity.Id,
                            $"قام بتغيير تاريخ التوريد الأولي لبيان الصلاحية من {oldvalidity.InitialSupplyDate} الي {newValidity.InitialSupplyDate}");
                        oldvalidity.InitialSupplyDate= newValidity.InitialSupplyDate;
                    }

                    if (newValidity.ValidatySupplyDate != null && oldvalidity.ValidatySupplyDate == null)
                    {
                        log.AddLog(adminId, "ValidityStatments", "ValidatySupplyDate", oldvalidity.Id,
                            "قام بإضافة تاريخ توريد بيان الصلاحية");
                        oldvalidity.ValidatySupplyDate = newValidity.ValidatySupplyDate;
                    }
                    else if(newValidity.ValidatySupplyDate != null && oldvalidity.ValidatySupplyDate != null)
                    {
                        log.AddLog(adminId, "ValidityStatments", "ValidatySupplyDate", oldvalidity.Id,
                            $"قام بتغيير تاريخ توريد بيان الصلاحية من {oldvalidity.ValidatySupplyDate} الي {newValidity.ValidatySupplyDate}");
                        oldvalidity.ValidatySupplyDate= newValidity.ValidatySupplyDate;
                    }

                    if (newValidity.ReceiveDate != null && oldvalidity.ReceiveDate == null)
                    {
                        log.AddLog(adminId, "ValidityStatments", "ReceiveDate", oldvalidity.Id,
                            "قام بإضافة تاريخ الاستلام لبيان الصلاحية");
                        oldvalidity.ReceiveDate= newValidity.ReceiveDate;
                    }
                    else if(newValidity.ReceiveDate != null && oldvalidity.ReceiveDate != null)
                    {
                        log.AddLog(adminId, "ValidityStatments", "ReceiveDate", oldvalidity.Id,
                            $"قام بتغيير تاريخ الاستلام لبيان الصلاحية من {oldvalidity.ReceiveDate} الي {newValidity.ReceiveDate}");
                        oldvalidity.ReceiveDate = newValidity.ReceiveDate;
                    }

                    return await context.SaveChangesAsync();
                }
            }
            return 0;
        }
    }
}
