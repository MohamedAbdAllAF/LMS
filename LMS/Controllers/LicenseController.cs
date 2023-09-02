using LMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    internal class LicenseController
    {
        LMSContext context = new LMSContext();
        ExceptionHandler errHandle = new ExceptionHandler();
        UserController userControl = new UserController();
        LocationController locationControl = new LocationController();
        ValidityStatmentController ValidityControl =new ValidityStatmentController();
        AdminLogController Log = new AdminLogController();

        public bool AddLicense(int adminId, User owner, User agent, ValidityStatment validityStatment, string location, license license)
        {
            int ownerId = userControl.AddNewUser(adminId,owner);
            int agentId = userControl.AddNewUser(adminId,agent);
            int locationId = locationControl.AddNewLocation(adminId,location);
            int validityId = ValidityControl.AddNewValidityStatment(adminId,validityStatment);
            license.OwnerID = ownerId;
            license.AgentID = agentId;
            license.LocationId = locationId;
            license.ValidityStatId = validityId;
            license.CreatedOn = DateTime.Now;
            try
            {
                context.Licenses.Add(license);
                context.SaveChanges();
                var recId = context.Licenses.Max(l => l.Id);

                Log.AddLog(adminId, "licenses", "OwnerID", recId, "قام بإضافة المالك");
                Log.AddLog(adminId, "licenses", "AgentID", recId, "قام بإضافة الوكيل");
                Log.AddLog(adminId, "licenses", "LocationId", recId, "قام بإضافة الموقع");
                Log.AddLog(adminId, "licenses", "ValidityStatId", recId, "قام بإضافة بيانات بيان الصلاحية");
                if (license.PlotNumber!=null)
                    Log.AddLog(adminId, "licenses", "PlotNumber", recId, "قام بإضافة رقم القطعة");
                if(license.Work != null)
                    Log.AddLog(adminId, "licenses", "Work", recId, "قام بإضافة بيان الأعمال");
                if(license.Fees != null)
                    Log.AddLog(adminId, "licenses", "Fees", recId, "قام بإضافة قيمة الأتعاب");
                if(license.LicenseNumber!=null)
                    Log.AddLog(adminId, "licenses", "LicenseNumber", recId, "قام بإضافة رقم الرخصة");
                if (license.EntryDate != null)
                    Log.AddLog(adminId, "licenses", "EntryDate", recId, "قام بإضافة تاريخ الدخول للرخصة");
                if (license.ExaminationFeeDate != null)
                    Log.AddLog(adminId, "licenses", "ExaminationFeeDate", recId, "قام بإضافة تاريخ رسم الفحص للرخصة");
                if (license.FeesPaymentDate != null)
                    Log.AddLog(adminId, "licenses", "FeesPaymentDate", recId, "قام بإضافة تاريخ دفع الرسوم للرخصة");
                if (license.SignatureDate != null)
                    Log.AddLog(adminId, "licenses", "SignatureDate", recId, "قام بإضافة تاريخ التوقيع للرخصة");
                if (license.ReceiveDate != null)
                    Log.AddLog(adminId, "licenses", "ReceiveDate", recId, "قام بإضافة تاريخ الأستلام للرخصة");
                if (license.Notes != null)
                    Log.AddLog(adminId, "licenses", "Notes", recId, "قام بإضافة ملاحظات ");

                return true;
            }
            catch (Exception ex)
            {
                errHandle.AddExeption(ex, "LicenseController", "AddLicense", DateTime.Now);
                return false;
            }
        }
    }
}
