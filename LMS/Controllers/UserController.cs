using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    internal class UserController
    {
        LMSContext context = new LMSContext();
        ExceptionHandler errHandle = new ExceptionHandler();
        AdminLogController LogControl = new AdminLogController();

        // Function To Add User And Retreive his ID 
        public int AddNewUser(int adminId,User user)
        {
            if (IsExist(user.NationalId))
            {
                try
                {
                    var userId = context.Users.Where(u => u.NationalId == user.NationalId).Select(u => u.Id).FirstOrDefault();
                    return Convert.ToInt32(userId);
                }
                catch (Exception ex)
                {
                    errHandle.AddExeption(ex, "UserController", "AddNewUser", DateTime.Now);
                    return -1;
                }
            }
            else
            {
                try
                {
                    context.Users.Add(new User { Name = user.Name, NationalId = user.NationalId });
                    context.SaveChanges();
                    var userId = context.Users.Where(u => u.NationalId == user.NationalId).Select(u => u.Id).FirstOrDefault();
                    LogControl.AddLog(adminId, "Users", "NationalId", userId, "قام بإضافة الرقم القومي الخاص بالمستخدم");
                    LogControl.AddLog(adminId, "Users", "Name", userId, "قام بإضافة اسم المستخدم");
                    context.SaveChanges();
                    return Convert.ToInt32(userId);
                }
                catch (Exception ex)
                {
                    errHandle.AddExeption(ex, "UserController", "AddNewUser", DateTime.Now);
                    return -1;
                }
            }
        }

        public bool IsExist(string nationalId)
        {
            return context.Users.Any(user=>user.NationalId == nationalId);
        }
    }
}
