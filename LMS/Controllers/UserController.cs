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
            if (IsExist(user.Name))
            {
                try
                {
                    var userId = context.Users.Where(u => u.Name == user.Name).Select(u => u.Id).FirstOrDefault();
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
                    var isUserExist = context.Users.Where(u => u.NationalId == user.NationalId).FirstOrDefault();
                    if(isUserExist != null)
                        return Convert.ToInt32(isUserExist.Id);
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

        public bool IsExist(string Name)
        {
            return context.Users.Any(user=>user.Name == Name);
        }
        public int UpdateUser(int adminId, User user)
        {
            var oldUser = context.Users.FirstOrDefault(u => u.NationalId == user.NationalId);
            string name = oldUser.Name;
            oldUser.Name = user.Name;
            int result = context.SaveChanges();
            if (result > 0)
            {
                LogControl.
                    AddLog(adminId, "Users", "Name", oldUser.Id,
                    $"قام بتغيير اسم المستخدم من {name} الي {user.Name}");
                return result;
            }
            return -1;
        }
    }
}
