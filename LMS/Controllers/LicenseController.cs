using LMS.Models;
using LMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
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
        AttachedFilesController _attachedFilesController = new AttachedFilesController();

        public async Task<string> NationalIdGenrator()
        {
            var id = 0;
            var users = await context.Users.ToListAsync();
            if (users.Count != 0)
                id = await context.Users.MaxAsync(u => u.Id);
            return id.ToString("D14");
        }

        public async Task<bool> AddLicense(int adminId, User owner, User agent,
            ValidityStatment validityStatment, string location, license license, List<(int id, string FileName, string Extension, byte[] Data)> fileList)
        {
            if (owner.NationalId == "")
                owner.NationalId = await NationalIdGenrator();
            int ownerId = await userControl.AddNewUser(adminId,owner);
            int agentId;
            if (agent == null)
                agentId = ownerId;
            else
                agentId = await userControl.AddNewUser(adminId,agent);
            int locationId = await locationControl.AddNewLocation(adminId,location);
            int validityId = await ValidityControl.AddNewValidityStatment(adminId,validityStatment);
            license.OwnerID = ownerId;
            license.AgentID = agentId;
            license.LocationId = locationId;
            license.ValidityStatId = validityId;
            license.CreatedOn = DateTime.Now;
            try
            {
                context.Licenses.Add(license);
                await context.SaveChangesAsync();
                var recId = await context.Licenses.MaxAsync(l => l.Id);

                await _attachedFilesController.AddFiles(adminId, recId, fileList);
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

        public async Task<List<LicenseVM>> GetAllLicensesForReports()
        {
            List<LicenseVM> result = new List<LicenseVM>();

            var licenses = await context.Licenses.ToListAsync();

            foreach (var license in licenses)
            {
                LicenseVM licenseVM;
                var owner = await context.Users.FirstOrDefaultAsync(u => u.Id == license.OwnerID);
                var agent = await context.Users.FirstOrDefaultAsync(u => u.Id == license.AgentID);
                var location = await context.Locations.FirstOrDefaultAsync(l => l.Id == license.LocationId);
                var validationStat = await context.validityStatments.FirstOrDefaultAsync(v => v.Id == license.ValidityStatId);

                licenseVM = new LicenseVM
                {
                    OwnarName = owner.Name,
                    OwnarNationalId = owner.NationalId,
                    //AgentName = agent.Name,
                    //AgentNationalId = agent.NationalId,
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
                if (agent == null)
                    licenseVM.AgentName = licenseVM.AgentNationalId = "";
                else
                {
                    licenseVM.AgentName = agent.Name;
                    licenseVM.AgentNationalId = agent.NationalId;
                }
                result.Add(licenseVM);
            }
            return result;
        }

        public async Task<List<LicenseVM>> GetAllLicensesInRange(DateTime From,DateTime To,string Choice)
        {
            List<LicenseVM> result = new List<LicenseVM>();

            List<license> licenses = null;
            if (Choice == "CreatedOn")
                licenses = await context.Licenses.Where(l => l.CreatedOn >= From && l.CreatedOn <= To).ToListAsync();
            else if (Choice == "LEntryDate")
                licenses = await context.Licenses.Where(l => l.EntryDate >= From && l.EntryDate <= To).ToListAsync();
            else if (Choice == "LExaminationFeeDate")
                licenses = await context.Licenses.Where(l => l.ExaminationFeeDate >= From && l.ExaminationFeeDate <= To).ToListAsync();
            else if (Choice == "LFinalPaymentDate")
                licenses = await context.Licenses.Where(l => l.FinalPaymentDate >= From && l.FinalPaymentDate <= To).ToListAsync();
            else if (Choice == "LInitialSupplyDate")
                licenses = await context.Licenses.Where(l => l.InitialSupplyDate >= From && l.InitialSupplyDate <= To).ToListAsync();
            else if (Choice == "VEntryDate")
                licenses = await context.Licenses.Where(l => l.ValStat.EntryDate >= From && l.ValStat.EntryDate <= To).ToListAsync();
            else if (Choice == "VInitialSupplyDate")
                licenses = await context.Licenses.Where(l => l.ValStat.InitialSupplyDate >= From && l.ValStat.InitialSupplyDate <= To).ToListAsync();
            else if(Choice == "VValidatySupplyDate")
                licenses = await context.Licenses.Where(l => l.ValStat.ValidatySupplyDate >= From && l.ValStat.ValidatySupplyDate <= To).ToListAsync();

            foreach (var license in licenses)
            {
                LicenseVM licenseVM;
                var owner = await context.Users.FirstOrDefaultAsync(u => u.Id == license.OwnerID);
                var agent = await context.Users.FirstOrDefaultAsync(u => u.Id == license.AgentID);
                var location = await context.Locations.FirstOrDefaultAsync(l => l.Id == license.LocationId);
                var validationStat = await context.validityStatments.FirstOrDefaultAsync(v => v.Id == license.ValidityStatId);

                licenseVM = new LicenseVM
                {
                    OwnarName = owner.Name,
                    OwnarNationalId = owner.NationalId,
                    //AgentName = agent.Name,
                    //AgentNationalId = agent.NationalId,
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
                if (agent == null)
                    licenseVM.AgentName = licenseVM.AgentNationalId = "";
                else
                {
                    licenseVM.AgentName = agent.Name;
                    licenseVM.AgentNationalId = agent.NationalId;
                }
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

        public async Task<List<SearchVM>> SearchLicenseByOwnerNationalID(string id)
        { 
            List<SearchVM> result = new List<SearchVM>();
            var users = await context.Users.Where(u=>u.NationalId.Contains(id)).ToListAsync();
            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = await context.Licenses.Where(l => l.OwnerID == user.Id).ToListAsync();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var agent = await context.Users.Where(u => u.Id == license.AgentID).FirstOrDefaultAsync();
                            var location = await context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefaultAsync();
                            item = new SearchVM
                            {
                                LicenseId  =license.Id,
                                OwnerName = user.Name,
                                OwnerNationalId = user.NationalId,
                                //AgentName = agent.Name,
                                //AgentNationalId = agent.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            if (agent == null)
                                item.AgentName = item.AgentNationalId = "";
                            else
                            {
                                item.AgentName = agent.Name;
                                item.AgentNationalId = agent.NationalId;
                            }
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<List<SearchVM>> SearchLicenseByOwnerName(string key)
        {
            List<SearchVM> result = new List<SearchVM>();
            var users = await context.Users.Where(u => u.Name.Contains(key)).ToListAsync();
            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = await context.Licenses.Where(l => l.OwnerID == user.Id).ToListAsync();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var agent = await context.Users.Where(u => u.Id == license.AgentID).FirstOrDefaultAsync();
                            var location = await context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefaultAsync();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                OwnerName = user.Name,
                                OwnerNationalId = user.NationalId,
                                //AgentName = agent.Name,
                                //AgentNationalId = agent.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            if (agent == null)
                                item.AgentName = item.AgentNationalId = "";
                            else
                            {
                                item.AgentName = agent.Name;
                                item.AgentNationalId = agent.NationalId;
                            }
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<List<SearchVM>> SearchLicenseByOwnerNationalIdAndName(string nationalId,string name)
        {
            List<SearchVM> result = new List<SearchVM>();
            var users = await context.Users.Where(
                u => u.Name.Contains(name) && u.NationalId.Contains(nationalId)).ToListAsync();

            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = await context.Licenses.Where(l => l.OwnerID == user.Id).ToListAsync();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var agent = await context.Users.Where(u => u.Id == license.AgentID).FirstOrDefaultAsync();
                            var location = await context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefaultAsync();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                OwnerName = user.Name,
                                OwnerNationalId = user.NationalId,
                                //AgentName = agent.Name,
                                //AgentNationalId = agent.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            if (agent == null)
                                item.AgentName = item.AgentNationalId = "";
                            else
                            {
                                item.AgentName = agent.Name;
                                item.AgentNationalId = agent.NationalId;
                            }
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<List<SearchVM>> SearchLicenseByAgentNationalID(string id)
        {
            List<SearchVM> result = new List<SearchVM>();
            var users = await context.Users.Where(u => u.NationalId.Contains(id)).ToListAsync();
            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = await context.Licenses.Where(l => l.AgentID == user.Id).ToListAsync();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var owner = await context.Users.Where(u => u.Id == license.OwnerID).FirstOrDefaultAsync();
                            var location = await context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefaultAsync();
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

        public async Task<List<SearchVM>> SearchLicenseByAgentName(string key)
        {
            List<SearchVM> result = new List<SearchVM>();
            var users = await context.Users.Where(u => u.Name.Contains(key)).ToListAsync();
            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = await context.Licenses.Where(l => l.AgentID == user.Id).ToListAsync();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var owner = await context.Users.Where(u => u.Id == license.OwnerID).FirstOrDefaultAsync();
                            var location = await context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefaultAsync();
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

        public async Task<List<SearchVM>> SearchLicenseByAgentNameAndNationalId(string nationaId,string name)
        {
            List<SearchVM> result = new List<SearchVM>();
            var users = await context.Users.Where(
                u => u.Name.Contains(name) && u.NationalId.Contains(nationaId)).ToListAsync();

            if (users != null)
            {
                foreach (var user in users)
                {
                    SearchVM item;
                    var licenses = await context.Licenses.Where(l => l.AgentID == user.Id).ToListAsync();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var owner = await context.Users.Where(u => u.Id == license.OwnerID).FirstOrDefaultAsync();
                            var location = await context.Locations.Where(l => l.Id == license.LocationId).FirstOrDefaultAsync();
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

        public async Task<List<SearchVM>> SearchLicenseByLocation(string key)
        {
            List<SearchVM> result = new List<SearchVM>();
            var locations = await context.Locations.Where(u => u.Name.Contains(key)).ToListAsync();
            if (locations != null)
            {
                foreach (var location in locations)
                {
                    SearchVM item;
                    var licenses = await context.Licenses.Where(l => l.LocationId == location.Id).ToListAsync();
                    if (licenses != null)
                    {
                        foreach (var license in licenses)
                        {
                            var agent = await context.Users.Where(u => u.Id == license.AgentID).FirstOrDefaultAsync();
                            var owner = await context.Users.Where(u => u.Id == license.OwnerID).FirstOrDefaultAsync();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                OwnerName = owner.Name,
                                OwnerNationalId = owner.NationalId,
                                //AgentName = agent.Name,
                                //AgentNationalId = agent.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            if (agent == null)
                                item.AgentName = item.AgentNationalId = "";
                            else
                            {
                                item.AgentName = agent.Name;
                                item.AgentNationalId = agent.NationalId;
                            }
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<List<SearchVM>> SearchLicenseByPlotNumber(string key)
        {
            List<SearchVM> result = new List<SearchVM>();
            var licenses = await context.Licenses.Where(u => u.PlotNumber.Contains(key)).ToListAsync();
            if (licenses != null)
            {
                foreach (var license in licenses)
                {
                    SearchVM item;
                    var locations = await context.Locations.Where(l => l.Id == license.LocationId).ToListAsync();
                    if (licenses != null)
                    {
                        foreach (var location in locations)
                        {
                            var agent = await context.Users.Where(u => u.Id == license.AgentID).FirstOrDefaultAsync();
                            var owner = await context.Users.Where(u => u.Id == license.OwnerID).FirstOrDefaultAsync();
                            item = new SearchVM
                            {
                                LicenseId = license.Id,
                                OwnerName = owner.Name,
                                OwnerNationalId = owner.NationalId,
                                //AgentName = agent.Name,
                                //AgentNationalId = agent.NationalId,
                                Location = location.Name,
                                PlotNumber = license.PlotNumber
                            };
                            if (agent == null)
                                item.AgentName = item.AgentNationalId = "";
                            else
                            {
                                item.AgentName = agent.Name;
                                item.AgentNationalId = agent.NationalId;
                            }
                            result.Add(item);
                        }
                    }
                }
            }
            return result;
        }

        public async Task<List<SearchVM>> SearchLicenseByLocationAndPlotNumber(string location,string plotNumber)
        {
            List<SearchVM> result = new List<SearchVM>();
            List<SearchVM> plots = await SearchLicenseByPlotNumber(plotNumber);
            if(plots != null)
            {
                result = plots.Where(p=>p.Location.Contains(location)).ToList();
            }
            return result;
        }

        public async Task<LicenseVM> GetLicenseVM(int licenseId)
        {
            LicenseVM result = new LicenseVM();
            var license = await context.Licenses.FirstOrDefaultAsync(l=>l.Id == licenseId);
            if(license != null)
            {
                var owner = await context.Users.FirstOrDefaultAsync(u => u.Id == license.OwnerID);
                var agent = await context.Users.FirstOrDefaultAsync(u => u.Id == license.AgentID);
                var location = await context.Locations.FirstOrDefaultAsync(l => l.Id == license.LocationId);
                var validaty = await context.validityStatments.FirstOrDefaultAsync(v => v.Id == license.ValidityStatId);
                var files = await context.AttachedFiles.Where(f => f.LicenseId == licenseId).ToListAsync();

                List<(int id, string FileName, string Extension, byte[] Data)> fileList = new List<(int, string, string, byte[])>();
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        fileList.Add((file.Id, file.FileName, file.FileExtension, file.FileData));
                    }
                }

                result = new LicenseVM
                {
                    OwnarNationalId = owner.NationalId,
                    OwnarName = owner.Name,
                    //AgentNationalId = agent.NationalId,
                    //AgentName = agent.Name,
                    Location = location.Name,
                    PlotNumber = license.PlotNumber,
                    Work = license.Work,
                    Fees = license.Fees,
                    fileList = fileList,
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
                if (agent == null)
                    result.AgentName = result.AgentNationalId = "";
                else
                {
                    result.AgentName = agent.Name;
                    result.AgentNationalId = agent.NationalId;
                }

            }
            return result;
        }

        public async Task<bool> UpdateLicense(int adminId,int id,LicenseVM newlicense)
        {
            try
            {
                var oldlicence = await context.Licenses.FirstOrDefaultAsync(l => l.Id == id);
                var oldOwner = await context.Users.FirstOrDefaultAsync(l => l.Id == oldlicence.OwnerID);
                var oldAgent = await context.Users.FirstOrDefaultAsync(u => u.Id == oldlicence.AgentID);
                var oldLocation = await context.Locations.FirstOrDefaultAsync(l => l.Id == oldlicence.LocationId);
                var oldvalidity = await context.validityStatments.FirstOrDefaultAsync(v => v.Id == oldlicence.ValidityStatId);

                if (oldOwner.NationalId != newlicense.OwnarNationalId)
                {
                    if (newlicense.OwnarNationalId == "")
                        newlicense.OwnarNationalId = await NationalIdGenrator();
                    int ownerId = await userControl.AddNewUser(adminId, new User
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
                        int x = await userControl.UpdateUser(adminId, new User
                        {
                            Name = newlicense.OwnarName,
                            NationalId = newlicense.OwnarNationalId
                        });
                    }
                }
                
                if(oldAgent == null)
                {
                    if (newlicense.AgentNationalId == "" && newlicense.AgentName == "")
                    {
                        oldlicence.AgentID = null;
                    }
                    else if (newlicense.AgentNationalId != string.Empty || newlicense.AgentNationalId != "")
                    {
                        if (newlicense.AgentNationalId == "")
                            newlicense.AgentNationalId = await NationalIdGenrator();
                        int agentId = await userControl.AddNewUser(adminId, new User
                        {
                            NationalId = newlicense.AgentNationalId,
                            Name = newlicense.AgentName
                        });
                        oldlicence.AgentID = agentId;
                        Log.AddLog(adminId, "Licenses", "N/A", oldlicence.Id,
                            $"قام بأضافة بيانات الوكيل الي {agentId}");
                    }
                }
                else if(newlicense.AgentNationalId == "" && newlicense.AgentName == "")
                {
                    oldlicence.AgentID = null;
                    Log.AddLog(adminId, "Licenses", "N/A", oldlicence.Id,
                        $"قام بحذف بيانات الوكيل من {oldAgent.Id} الي 0");
                }
                else if (oldAgent.NationalId != newlicense.AgentNationalId)
                {
                    if (newlicense.AgentNationalId == "")
                        newlicense.AgentNationalId = await NationalIdGenrator();
                    int agentId = await userControl.AddNewUser(adminId, new User
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
                        int x = await userControl.UpdateUser(adminId, new User
                        {
                            Name = newlicense.AgentName,
                            NationalId = newlicense.AgentNationalId
                        });
                    }
                }

                if (oldLocation.Name != newlicense.Location)
                {
                    int locationId = await locationControl.AddNewLocation(adminId, newlicense.Location);
                    oldlicence.LocationId = locationId;
                    Log.AddLog(adminId, "Licenses", "N/A", oldlicence.Id,
                        $"قام بتغيير بيانات الموقع من {oldLocation.Id} الي {locationId}");
                }

                await ValidityControl.UpdateValidityStatment(adminId, new ValidityStatment
                {
                    Id = (int)oldlicence.ValidityStatId,
                    EntryDate = newlicense.VEntryDate,
                    InitialSupplyDate = newlicense.VInitialSupplyDate,
                    ValidatySupplyDate = newlicense.VValidatySupplyDate,
                    ReceiveDate = newlicense.VReceiveDate
                });

                await _attachedFilesController.AddFiles(adminId, id, newlicense.fileList);

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
                await context.SaveChangesAsync();
                return true;
            }catch (Exception ex)
            {
                errHandle.AddExeption(ex, "LicenseController", "UpdateLicense",DateTime.Now);
                return false;
            }
        }

        public async Task<bool> DeleteLicense(int adminId,int License)
        {
            var oldlicence = await context.Licenses.FirstOrDefaultAsync(l => l.Id == License);
            try
            {
                if (oldlicence != null)
                {
                    context.Licenses.Remove(oldlicence);
                    Log.AddLog(adminId, "Licenses", "N/A", oldlicence.Id,"قام بحذف رخصة");
                    await context.SaveChangesAsync();
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
