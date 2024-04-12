using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    internal class AttachedFilesController
    {
        LMSContext _context = new LMSContext();
        ExceptionHandler _errHandle = new ExceptionHandler();
        AdminLogController _log = new AdminLogController();

        public bool AddFiles(int adminId, int licenseId, List<(int id, string FileName, string Extension, byte[] Data)> fileList)
        {
            try
            {
                foreach (var file in fileList)
                {
                    var filemodel = new AttachedFiles
                    {
                        FileName = file.FileName,
                        FileExtension = file.Extension,
                        FileData = file.Data,
                        LicenseId = licenseId
                    };
                    _context.AttachedFiles.Add(filemodel);
                    _context.SaveChanges();
                    _log.AddLog(adminId, "AttachedFiles", "N/A", filemodel.Id, "قام بإضافة ملف");
                }
                return true;
            }
            catch (Exception ex)
            {
                _errHandle.AddExeption(ex, "AttachedFilesController", "AddFiles", DateTime.Now);
                return false;
            }
        }

        public bool DeleteFiles(int adminId, List<(int id, string FileName, string Extension, byte[] Data)> fileList)
        {
            try
            {
                foreach (var file in fileList)
                {
                    var filedata = _context.AttachedFiles.FirstOrDefault(fe => fe.Id == file.id);
                    _context.AttachedFiles.Remove(filedata);
                    _log.AddLog(adminId, "AttachedFiles", "N/A", file.id, "قام بحذف ملف");
                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _errHandle.AddExeption(ex, "AttachedFilesController", "DeleteFiles", DateTime.Now);
                return false;
            }
        }
    }
}
