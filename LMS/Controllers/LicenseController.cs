using LMS.Models;
using LMS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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

        public bool AddLicense(int adminId, User owner, User agent,
            ValidityStatment validityStatment, string location, license license)
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

        public LicenseVM DisplayLicense(int licenseId)
        {
            LicenseVM licenseVM;

            var license = context.Licenses.FirstOrDefault(l => l.Id == licenseId);
            var owner = context.Users.FirstOrDefault(u=> u.Id == license.OwnerID);
            var agent = context.Users.FirstOrDefault(u => u.Id == license.AgentID);
            var location = context.Locations.FirstOrDefault(l => l.Id == license.LocationId);
            var validationStat = context.validityStatments.FirstOrDefault(v => v.Id == license.ValidityStatId);

            licenseVM = new LicenseVM
            {
                OwnarName = owner.Name,
                OwnarNationalId = owner.NationalId,
                AgentName = agent.Name,
                AgentNationalId = agent.NationalId,
                Location = location.Name,
                PlotNumber = license.PlotNumber,
                Work = license.Work,
                Fees = license.Fees,
                LicenseNumber = license.LicenseNumber,
                Notes = license.Notes,
                VEntryDate = validationStat.EntryDate,
                VInitialSupplyDate = validationStat.InitialSupplyDate,
                VReceiveDate = validationStat.ReceiveDate,
                VValidatySupplyDate = validationStat.ValidatySupplyDate,
                LEntryDate = license.EntryDate,
                LExaminationFeeDate = license.ExaminationFeeDate,
                LFeesPaymentDate = license.FeesPaymentDate,
                LReceiveDate = license.ReceiveDate,
                LSignatureDate = license.SignatureDate,
                CreatedOn = license.CreatedOn
            };
            return licenseVM;
        }

        public List<SearchVM> SearchLicenseByOwnerNationalID(string id)
        { 
            List<SearchVM> result = new List<SearchVM>();
            var users = context.Users.Where(u=>u.NationalId.Contains(id)).ToList();
            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = context.Licenses.Where(l => l.OwnerID == user.Id).ToList();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var agent = context.Users.Where(u => u.Id == license.AgentID).FirstOrDefault();
                            var location = context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefault();
                            item = new SearchVM
                            {
                                LicenseId  =license.Id,
                                OwnerName = user.Name,
                                OwnerNationalId = user.NationalId,
                                AgentName = agent.Name,
                                AgentNationalId = agent.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public List<SearchVM> SearchLicenseByOwnerName(string key)
        {
            List<SearchVM> result = new List<SearchVM>();
            var users = context.Users.Where(u => u.Name.Contains(key)).ToList();
            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = context.Licenses.Where(l => l.OwnerID == user.Id).ToList();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var agent = context.Users.Where(u => u.Id == license.AgentID).FirstOrDefault();
                            var location = context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefault();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                OwnerName = user.Name,
                                OwnerNationalId = user.NationalId,
                                AgentName = agent.Name,
                                AgentNationalId = agent.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public List<SearchVM> SearchLicenseByOwnerNationalIdAndName(string nationalId,string name)
        {
            List<SearchVM> result = new List<SearchVM>();
            var users = context.Users.Where(
                u => u.Name.Contains(name) && u.NationalId.Contains(nationalId)).ToList();

            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = context.Licenses.Where(l => l.OwnerID == user.Id).ToList();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var agent = context.Users.Where(u => u.Id == license.AgentID).FirstOrDefault();
                            var location = context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefault();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                OwnerName = user.Name,
                                OwnerNationalId = user.NationalId,
                                AgentName = agent.Name,
                                AgentNationalId = agent.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public List<SearchVM> SearchLicenseByAgentNationalID(string id)
        {
            List<SearchVM> result = new List<SearchVM>();
            var users = context.Users.Where(u => u.NationalId.Contains(id)).ToList();
            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = context.Licenses.Where(l => l.AgentID == user.Id).ToList();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var owner = context.Users.Where(u => u.Id == license.OwnerID).FirstOrDefault();
                            var location = context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefault();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                AgentName = user.Name,
                                AgentNationalId = user.NationalId,
                                OwnerName = owner.Name,
                                OwnerNationalId = owner.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public List<SearchVM> SearchLicenseByAgentName(string key)
        {
            List<SearchVM> result = new List<SearchVM>();
            var users = context.Users.Where(u => u.Name.Contains(key)).ToList();
            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = context.Licenses.Where(l => l.AgentID == user.Id).ToList();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var owner = context.Users.Where(u => u.Id == license.OwnerID).FirstOrDefault();
                            var location = context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefault();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                AgentName = user.Name,
                                AgentNationalId = user.NationalId,
                                OwnerName = owner.Name,
                                OwnerNationalId = owner.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public List<SearchVM> SearchLicenseByAgentNameAndNationalId(string nationaId,string name)
        {
            List<SearchVM> result = new List<SearchVM>();
            var users = context.Users.Where(
                u => u.Name.Contains(name) && u.NationalId.Contains(nationaId)).ToList();

            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = context.Licenses.Where(l => l.AgentID == user.Id).ToList();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var owner = context.Users.Where(u => u.Id == license.OwnerID).FirstOrDefault();
                            var location = context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefault();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                AgentName = user.Name,
                                AgentNationalId = user.NationalId,
                                OwnerName = owner.Name,
                                OwnerNationalId = owner.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public List<SearchVM> SearchLicenseByLocation(string key)
        {
            List<SearchVM> result = new List<SearchVM>();
            var locations = context.Locations.Where(u => u.Name.Contains(key)).ToList();
            if (locations != null)
            {
                foreach (var location in locations)
                {
                    SearchVM item;
                    var licenses = context.Licenses.Where(l => l.LocationId == location.Id).ToList();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var agent = context.Users.Where(u => u.Id == license.AgentID).FirstOrDefault();
                            var owner = context.Users.Where(u => u.Id == license.OwnerID).FirstOrDefault();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                OwnerName = owner.Name,
                                OwnerNationalId = owner.NationalId,
                                AgentName = agent.Name,
                                AgentNationalId = agent.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public List<SearchVM> SearchLicenseByPlotNumber(string key)
        {
            List<SearchVM> result = new List<SearchVM>();
            var licenses = context.Licenses.Where(u => u.PlotNumber.Contains(key)).ToList();
            if (licenses != null)
            {
                foreach (var license in licenses)
                {
                    SearchVM item;
                    var locations = context.Locations.Where(l => l.Id == license.LocationId).ToList();
                    if (licenses != null)
                    {
                        foreach (var location in locations)
                        {
                            var agent = context.Users.Where(u => u.Id == license.AgentID).FirstOrDefault();
                            var owner = context.Users.Where(u => u.Id == license.OwnerID).FirstOrDefault();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                OwnerName = owner.Name,
                                OwnerNationalId = owner.NationalId,
                                AgentName = agent.Name,
                                AgentNationalId = agent.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public List<SearchVM> SearchLicenseByLocationAndPlotNumber(string location,string plotNumber)
        {
            List<SearchVM> result = new List<SearchVM>();
            List<SearchVM> plots = SearchLicenseByPlotNumber(plotNumber);
            if(plots != null)
            {
                result = plots.Where(p=>p.Location.Contains(location)).ToList();
            }
            return result;
        }
    }
}
