using LMS.Models;
using LMS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Reflection;
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

        public string NationalIdGenrator()
        {
            var id = 0;
            if (context.Users.ToList().Count != 0)
                id = context.Users.Max(u => u.Id);
            return id.ToString("D14");
        }

        public bool AddLicense(int adminId, User owner, User agent,
            ValidityStatment validityStatment, string location, license license)
        {
            if (owner.NationalId == "")
                owner.NationalId = NationalIdGenrator();
            int ownerId = userControl.AddNewUser(adminId,owner);
            int agentId;
            if (agent == null)
                agentId = ownerId;
            else
                agentId = userControl.AddNewUser(adminId,agent);
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
                if (license.InitialSupplyDate != null)
                    Log.AddLog(adminId, "licenses", "InitialSupplyDate", recId, "قام بإضافة تاريخ الدفع الأولي");
                if (license.FinalPaymentDate != null)
                    Log.AddLog(adminId, "licenses", "FinalPaymentDate", recId, "قام بإضافة تاريخ الدفع النهائي");
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

        public DateTime? DateFormat(DateTime? _date)
        {
            if (_date == null)
                return null;
            else
            {
                DateTime newDate = (DateTime)_date;
                newDate = new DateTime(newDate.Year, newDate.Month, newDate.Day);
                return newDate;
            }
        }

        public List<LicenseVM> GetAllLicensesForReports()
        {
            List<LicenseVM> result = new List<LicenseVM>();

            var licenses = context.Licenses.ToList();

            foreach (var license in licenses)
            {
                LicenseVM licenseVM;
                var owner = context.Users.FirstOrDefault(u => u.Id == license.OwnerID);
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
                    VEntryDate = DateFormat(validationStat.EntryDate),
                    VInitialSupplyDate = DateFormat(validationStat.InitialSupplyDate),
                    VValidatySupplyDate = DateFormat(validationStat.ValidatySupplyDate),
                    //VReceiveDate = DateFormat((DateTime)validationStat.ReceiveDate),
                    LEntryDate = DateFormat(license.EntryDate),
                    LInitialSupplyDate =DateFormat(license.InitialSupplyDate),
                    LExaminationFeeDate = DateFormat(license.ExaminationFeeDate),
                    LFinalPaymentDate = DateFormat(license.FinalPaymentDate),
                    //LFeesPaymentDate = DateFormat((DateTime)license.FeesPaymentDate),
                    //LReceiveDate = DateFormat((DateTime)license.ReceiveDate),
                    //LSignatureDate = DateFormat((DateTime)license.SignatureDate),
                    //CreatedOn = (DateTime)DateFormat((DateTime)license.CreatedOn)
                };
                result.Add(licenseVM);
            }
            return result;
        }

        public List<LicenseVM> GetAllLicensesInRange(DateTime From,DateTime To,string Choice)
        {
            List<LicenseVM> result = new List<LicenseVM>();

            List<license> licenses = null;
            if (Choice == "CreatedOn")
                licenses = context.Licenses.Where(l => l.CreatedOn >= From && l.CreatedOn <= To).ToList();
            else if (Choice == "LEntryDate")
                licenses = context.Licenses.Where(l => l.EntryDate >= From && l.EntryDate <= To).ToList();
            else if (Choice == "LExaminationFeeDate")
                licenses = context.Licenses.Where(l => l.ExaminationFeeDate >= From && l.ExaminationFeeDate <= To).ToList();
            else if (Choice == "LFinalPaymentDate")
                licenses = context.Licenses.Where(l => l.FinalPaymentDate >= From && l.FinalPaymentDate <= To).ToList();
            else if (Choice == "LInitialSupplyDate")
                licenses = context.Licenses.Where(l => l.InitialSupplyDate >= From && l.InitialSupplyDate <= To).ToList();
            else if (Choice == "VEntryDate")
                licenses = context.Licenses.Where(l => l.ValStat.EntryDate >= From && l.ValStat.EntryDate <= To).ToList();
            else if (Choice == "VInitialSupplyDate")
                licenses = context.Licenses.Where(l => l.ValStat.InitialSupplyDate >= From && l.ValStat.InitialSupplyDate <= To).ToList();
            else if(Choice == "VValidatySupplyDate")
                licenses = context.Licenses.Where(l => l.ValStat.ValidatySupplyDate >= From && l.ValStat.ValidatySupplyDate <= To).ToList();

            foreach (var license in licenses)
            {
                LicenseVM licenseVM;
                var owner = context.Users.FirstOrDefault(u => u.Id == license.OwnerID);
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
                    VEntryDate = DateFormat(validationStat.EntryDate),
                    VInitialSupplyDate = DateFormat(validationStat.InitialSupplyDate),
                    VValidatySupplyDate = DateFormat(validationStat.ValidatySupplyDate),
                    //VReceiveDate = DateFormat((DateTime)validationStat.ReceiveDate),
                    LEntryDate = DateFormat(license.EntryDate),
                    LInitialSupplyDate = DateFormat(license.InitialSupplyDate),
                    LExaminationFeeDate = DateFormat(license.ExaminationFeeDate),
                    LFinalPaymentDate = DateFormat(license.FinalPaymentDate),
                    //LFeesPaymentDate = DateFormat((DateTime)license.FeesPaymentDate),
                    //LReceiveDate = DateFormat((DateTime)license.ReceiveDate),
                    //LSignatureDate = DateFormat((DateTime)license.SignatureDate),
                    //CreatedOn = (DateTime)DateFormat((DateTime)license.CreatedOn)
                };
                result.Add(licenseVM);
            }
            return result;
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
                LInitialSupplyDate = license.InitialSupplyDate,
                LFinalPaymentDate = license.FinalPaymentDate,
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

        public LicenseVM GetLicenseVM(int licenseId)
        {
            LicenseVM result = new LicenseVM();
            var license = context.Licenses.FirstOrDefault(l=>l.Id == licenseId);
            if(license != null)
            {
                var owner = context.Users.FirstOrDefault(u => u.Id == license.OwnerID);
                var agent = context.Users.FirstOrDefault(u => u.Id == license.AgentID);
                var location = context.Locations.FirstOrDefault(l => l.Id == license.LocationId);
                var validaty = context.validityStatments.FirstOrDefault(v => v.Id == license.ValidityStatId);

                result = new LicenseVM
                {
                    OwnarNationalId = owner.NationalId,
                    OwnarName = owner.Name,
                    AgentNationalId = agent.NationalId,
                    AgentName = agent.Name,
                    Location = location.Name,
                    PlotNumber = license.PlotNumber,
                    Work = license.Work,
                    Fees = license.Fees,
                    LicenseNumber = license.LicenseNumber,
                    Notes = license.Notes,
                    LEntryDate = license.EntryDate,
                    LInitialSupplyDate = license.InitialSupplyDate,
                    LFinalPaymentDate = license.FinalPaymentDate,
                    LExaminationFeeDate = license.ExaminationFeeDate,
                    LFeesPaymentDate = license.FeesPaymentDate,
                    LSignatureDate = license.SignatureDate,
                    LReceiveDate = license.ReceiveDate,
                    VEntryDate = validaty.EntryDate,
                    VInitialSupplyDate = validaty.InitialSupplyDate,
                    VValidatySupplyDate = validaty.ValidatySupplyDate,
                    VReceiveDate = validaty.ReceiveDate,
                    LastUptate = license.LastUpdate,
                    CreatedOn = license.CreatedOn
                };
            }
            return result;
        }

        public int UpdateLicense(int adminId,int id,LicenseVM newlicense)
        {
            try
            {
                var oldlicence = context.Licenses.FirstOrDefault(l => l.Id == id);
                var oldOwner = context.Users.FirstOrDefault(l => l.Id == oldlicence.OwnerID);
                var oldAgent = context.Users.FirstOrDefault(u => u.Id == oldlicence.AgentID);
                var oldLocation = context.Locations.FirstOrDefault(l => l.Id == oldlicence.LocationId);
                var oldvalidity = context.validityStatments.FirstOrDefault(v => v.Id == oldlicence.ValidityStatId);

                if (oldOwner.NationalId != newlicense.OwnarNationalId)
                {
                    if (newlicense.OwnarNationalId == "")
                        newlicense.OwnarNationalId = NationalIdGenrator();
                    int ownerId = userControl.AddNewUser(adminId, new User
                    {
                        NationalId = newlicense.OwnarNationalId,
                        Name = newlicense.OwnarName
                    });
                    oldlicence.OwnerID = ownerId;
                    Log.AddLog(adminId, "Licenses", "N/A", oldlicence.Id,
                        $"قام بتغيير بيانات المالك من {oldOwner.Id} الي {ownerId}");
                }
                else if (oldOwner.NationalId == newlicense.OwnarNationalId)
                {
                    if (oldOwner.Name != newlicense.OwnarName)
                    {
                        int x = userControl.UpdateUser(adminId, new User
                        {
                            Name = newlicense.OwnarName,
                            NationalId = newlicense.OwnarNationalId
                        });
                    }
                }

                if (oldAgent.NationalId != newlicense.AgentNationalId)
                {
                    if (newlicense.AgentNationalId == "")
                        newlicense.AgentNationalId = NationalIdGenrator();
                    int agentId = userControl.AddNewUser(adminId, new User
                    {
                        NationalId = newlicense.AgentNationalId,
                        Name = newlicense.AgentName
                    });
                    oldlicence.AgentID = agentId;
                    Log.AddLog(adminId, "Licenses", "N/A", oldlicence.Id,
                        $"قام بتغيير بيانات الوكيل من {oldAgent.Id} الي {agentId}");
                }
                else if (oldAgent.NationalId == newlicense.AgentNationalId)
                {
                    if (oldAgent.Name != newlicense.AgentName)
                    {
                        int x = userControl.UpdateUser(adminId, new User
                        {
                            Name = newlicense.AgentName,
                            NationalId = newlicense.AgentNationalId
                        });
                    }
                }

                if (oldLocation.Name != newlicense.Location)
                {
                    int locationId = locationControl.AddNewLocation(adminId, newlicense.Location);
                    oldlicence.LocationId = locationId;
                    Log.AddLog(adminId, "Licenses", "N/A", oldlicence.Id,
                        $"قام بتغيير بيانات الموقع من {oldLocation.Id} الي {locationId}");
                }

                ValidityControl.UpdateValidityStatment(adminId, new ValidityStatment
                {
                    Id = (int)oldlicence.ValidityStatId,
                    EntryDate = newlicense.VEntryDate,
                    InitialSupplyDate = newlicense.VInitialSupplyDate,
                    ValidatySupplyDate = newlicense.VValidatySupplyDate,
                    ReceiveDate = newlicense.VReceiveDate
                });
                Log.AddLog(adminId, "Licenses", "N/A", oldlicence.Id,
                        "قام بتغيير بيانات بيان الصلاحية ");

                if (newlicense.PlotNumber != null && oldlicence.PlotNumber == null)
                {
                    Log.AddLog(adminId, "Licenses", "PlotNumber", oldlicence.Id,
                        "قام بإضافة رقم القطعة ");
                    oldlicence.PlotNumber = newlicense.PlotNumber;
                }
                else if (newlicense.PlotNumber != null && oldlicence.PlotNumber != null)
                {
                    Log.AddLog(adminId, "Licenses", "PlotNumber", oldlicence.Id,
                        $"قام بتغيير رقم القطعة من {oldlicence.PlotNumber} الي {newlicense.PlotNumber}");
                    oldlicence.PlotNumber = newlicense.PlotNumber;
                }

                if (newlicense.Work != null && oldlicence.Work == null)
                {
                    Log.AddLog(adminId, "Licenses", "Work", oldlicence.Id,
                        "قام بإضافة رقم الاعمال ");
                    oldlicence.Work = newlicense.Work;
                }
                else if (newlicense.Work != null && oldlicence.Work != null)
                {
                    Log.AddLog(adminId, "Licenses", "Work", oldlicence.Id,
                        $"قام بتغيير الاعمال من {oldlicence.Work} الي {newlicense.Work}");
                    oldlicence.Work = newlicense.Work;
                }

                if (newlicense.Fees != null && oldlicence.Fees == null)
                {
                    Log.AddLog(adminId, "Licenses", "Fees", oldlicence.Id,
                        "قام بإضافة قيمة الاتعاب ");
                    oldlicence.Fees = newlicense.Fees;
                }
                else if (newlicense.Fees != null && oldlicence.Fees != null)
                {
                    Log.AddLog(adminId, "Licenses", "Fees", oldlicence.Id,
                        $"قام بتغيير قيمة الاتعاب من {oldlicence.Fees} الي {newlicense.Fees}");
                    oldlicence.Fees = newlicense.Fees;
                }

                if (newlicense.LicenseNumber != null && oldlicence.LicenseNumber == null)
                {
                    Log.AddLog(adminId, "Licenses", "LicenseNumber", oldlicence.Id,
                        "قام بإضافة رقم الرخصة ");
                    oldlicence.LicenseNumber = newlicense.LicenseNumber;
                }
                else if (newlicense.LicenseNumber != null && oldlicence.LicenseNumber != null)
                {
                    Log.AddLog(adminId, "Licenses", "LicenseNumber", oldlicence.Id,
                        $"قام بتغيير رقم الرخصة من {oldlicence.LicenseNumber} الي {newlicense.LicenseNumber}");
                    oldlicence.LicenseNumber = newlicense.LicenseNumber;
                }

                if (newlicense.Notes != null && oldlicence.Notes == null)
                {
                    Log.AddLog(adminId, "Licenses", "Notes", oldlicence.Id,
                        "قام بإضافة ملاحظات ");
                    oldlicence.Notes = newlicense.Notes;
                }
                else if (newlicense.Notes != null && oldlicence.Notes != null)
                {
                    Log.AddLog(adminId, "Licenses", "Notes", oldlicence.Id,
                        $"قام بتغيير الملاحظات من {oldlicence.Notes} الي {newlicense.Notes}");
                    oldlicence.Notes = newlicense.Notes;
                }

                if (newlicense.LEntryDate != null && oldlicence.EntryDate == null)
                {
                    Log.AddLog(adminId, "Licenses", "EntryDate", oldlicence.Id,
                        "قام بإضافة تاريخ الدخول ");
                    oldlicence.EntryDate = newlicense.LEntryDate;
                }
                else if (newlicense.LEntryDate != null && oldlicence.EntryDate != null)
                {
                    Log.AddLog(adminId, "Licenses", "EntryDate", oldlicence.Id,
                        $"قام بتغيير  تاريخ الدخول من {oldlicence.EntryDate} الي {newlicense.LEntryDate}");
                    oldlicence.EntryDate = newlicense.LEntryDate;
                }

                if (newlicense.LInitialSupplyDate != null && oldlicence.InitialSupplyDate == null)
                {
                    Log.AddLog(adminId, "Licenses", "InitialSupplyDate", oldlicence.Id,
                        "قام بإضافة تاريخ دفع أولي ");
                    oldlicence.InitialSupplyDate = newlicense.LInitialSupplyDate;
                }
                else if (newlicense.LInitialSupplyDate != null && oldlicence.InitialSupplyDate != null)
                {
                    Log.AddLog(adminId, "Licenses", "InitialSupplyDate", oldlicence.Id,
                        $"قام بتغيير  تاريخ دفع أولي من {oldlicence.InitialSupplyDate} الي {newlicense.LInitialSupplyDate}");
                    oldlicence.InitialSupplyDate = newlicense.LInitialSupplyDate;
                }

                if (newlicense.LFinalPaymentDate != null && oldlicence.FinalPaymentDate == null)
                {
                    Log.AddLog(adminId, "Licenses", "InitialSupplyDate", oldlicence.Id,
                        "قام بإضافة تاريخ دفع أولي ");
                    oldlicence.FinalPaymentDate = newlicense.LFinalPaymentDate;
                }
                else if (newlicense.LFinalPaymentDate != null && oldlicence.FinalPaymentDate != null)
                {
                    Log.AddLog(adminId, "Licenses", "FinalPaymentDate", oldlicence.Id,
                        $"قام بتغيير  تاريخ دفع نهائى من {oldlicence.FinalPaymentDate} الي {newlicense.LFinalPaymentDate}");
                    oldlicence.FinalPaymentDate = newlicense.LFinalPaymentDate;
                }

                if (newlicense.LExaminationFeeDate != null && oldlicence.ExaminationFeeDate == null)
                {
                    Log.AddLog(adminId, "Licenses", "ExaminationFeeDate", oldlicence.Id,
                        "قام بإضافة تاريخ رسم الفحص ");
                    oldlicence.ExaminationFeeDate = newlicense.LExaminationFeeDate;
                }
                else if (newlicense.LExaminationFeeDate != null && oldlicence.ExaminationFeeDate != null)
                {
                    Log.AddLog(adminId, "Licenses", "ExaminationFeeDate", oldlicence.Id,
                        $"قام بتغيير  تاريخ رسم الفحص من {oldlicence.ExaminationFeeDate} الي {newlicense.LExaminationFeeDate}");
                    oldlicence.ExaminationFeeDate = newlicense.LExaminationFeeDate;
                }

                if (newlicense.LFeesPaymentDate != null && oldlicence.FeesPaymentDate == null)
                {
                    Log.AddLog(adminId, "Licenses", "FeesPaymentDate", oldlicence.Id,
                        "قام بإضافة تاريخ دفع الرسوم ");
                    oldlicence.FeesPaymentDate = newlicense.LFeesPaymentDate;
                }
                else if (newlicense.LFeesPaymentDate != null && oldlicence.FeesPaymentDate != null)
                {
                    Log.AddLog(adminId, "Licenses", "FeesPaymentDate", oldlicence.Id,
                        $"قام بتغيير  تاريخ دفع الرسوم من {oldlicence.FeesPaymentDate} الي {newlicense.LFeesPaymentDate}");
                    oldlicence.FeesPaymentDate = newlicense.LFeesPaymentDate;
                }

                if (newlicense.LSignatureDate != null && oldlicence.SignatureDate == null)
                {
                    Log.AddLog(adminId, "Licenses", "SignatureDate", oldlicence.Id,
                        "قام بإضافة تاريخ التوقيع ");
                    oldlicence.SignatureDate = newlicense.LSignatureDate;
                }
                else if (newlicense.LSignatureDate != null && oldlicence.SignatureDate != null)
                {
                    Log.AddLog(adminId, "Licenses", "SignatureDate", oldlicence.Id,
                        $"قام بتغيير  تاريخ التوقيع من {oldlicence.SignatureDate} الي {newlicense.LSignatureDate}");
                    oldlicence.SignatureDate = newlicense.LSignatureDate;
                }

                if (newlicense.LReceiveDate != null && oldlicence.ReceiveDate == null)
                {
                    Log.AddLog(adminId, "Licenses", "ReceiveDate", oldlicence.Id,
                        "قام بإضافة تاريخ التوقيع ");
                    oldlicence.ReceiveDate = newlicense.LReceiveDate;
                }
                else if (newlicense.LReceiveDate != null && oldlicence.ReceiveDate != null)
                {
                    Log.AddLog(adminId, "Licenses", "ReceiveDate", oldlicence.Id,
                        $"قام بتغيير  تاريخ التوقيع من {oldlicence.ReceiveDate} الي {newlicense.LReceiveDate}");
                    oldlicence.ReceiveDate = newlicense.LReceiveDate;
                }
                oldlicence.LastUpdate = newlicense.LastUptate;
                context.SaveChanges();
                return 1;
            }catch (Exception ex)
            {
                errHandle.AddExeption(ex, "LicenseController", "UpdateLicense",DateTime.Now);
                return -1;
            }
        }

        public bool DeleteLicense(int adminId,int License)
        {
            var oldlicence = context.Licenses.FirstOrDefault(l => l.Id == License);
            try
            {
                if (oldlicence != null)
                {
                    context.Licenses.Remove(oldlicence);
                    Log.AddLog(adminId, "Licenses", "N/A", oldlicence.Id,"قام بحذف رخصة");
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errHandle.AddExeption(ex, "LicenseController", "DeleteLicense", DateTime.Now);
                return false;
            }
            return false;
        }

        public List<license> GetAllLicenses()
        {
            return context.Licenses.ToList();
        }
    }
}
