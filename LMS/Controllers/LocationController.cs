using LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    internal class LocationController
    {
        LMSContext context = new LMSContext();
        ExceptionHandler errHandle = new ExceptionHandler();
        AdminLogController Log = new AdminLogController();

        public int AddNewLocation(int adminId,string location)
        {
            if (IsExist(location))
            {
                var id =context.Locations.Where(l=>l.Name == location).Select(l=>l.Id).FirstOrDefault();
                return id;
            }
            else
            {
                try
                {
                    context.Locations.Add(new Location { Name = location });
                    context.SaveChanges();
                    var id = context.Locations.Where(l => l.Name == location).Select(l => l.Id).FirstOrDefault();
                    Log.AddLog(adminId, "Locations", "Name", id, "قام بإضافة موقع");
                    return id;
                } catch (Exception ex)
                {
                    errHandle.AddExeption(ex, "LocationController", "AddNewLocation", DateTime.Now);
                    return -1;
                }
            }
        }

        public bool IsExist(string location)
        {
            return context.Locations.Any(l=>l.Name == location);
        }

        public List<Location> GetAllLocations()
        {
            var result = context.Locations.ToList();

            return result;
        }
    }
}
