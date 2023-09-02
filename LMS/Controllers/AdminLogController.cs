using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    internal class AdminLogController
    {
        LMSContext context = new LMSContext();
        ExceptionHandler errHandle = new ExceptionHandler();

        public bool AddLog(int adminId,string tableName,string columnName,int recordId,string message)
        {
            AdminLog log;
            log = new AdminLog
            {
                Time = DateTime.Now,
                AdminId = adminId,
                TableName = tableName,
                columnName = columnName,
                RecordId = recordId,
                Event = message
            };
            try
            {
                context.AdminLogs.Add(log);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                errHandle.AddExeption(ex, "AdminLogController", "AddLog", DateTime.Now);
                return false;
            }
        }
    }
}
