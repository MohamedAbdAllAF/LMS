using LMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Controllers
{
    internal class LocationController
    {
        LMSContext context = new LMSContext();
        ExceptionHandler errHandle = new ExceptionHandler();
        AdminLogController Log = new AdminLogController();

        public async Task<int> AddNewLocation(int adminId,string location)
        {
            if (await IsExist(location))
            {
                var id = await context.Locations.Where(l => l.Name == location).Select(l => l.Id).FirstOrDefaultAsync();
                return id;
            }
            else
            {
                try
                {
                    context.Locations.Add(new Location { Name = location });
                    await context.SaveChangesAsync();
                    var id = await context.Locations.Where(l => l.Name == location).Select(l => l.Id).FirstOrDefaultAsync();
                    Log.AddLog(adminId, "Locations", "Name", id, "قام بإضافة موقع");
                    return id;
                } catch (Exception ex)
                {
                    errHandle.AddExeption(ex, "LocationController", "AddNewLocation", DateTime.Now);
                    return -1;
                }
            }
        }

        public async Task<bool> IsExist(string location)
        {
            return await context.Locations.AnyAsync(l=>l.Name == location);
        }

        public async Task<List<Location>> GetAllLocations()
        {
            var result = await context.Locations.ToListAsync();

            return result;
        }
    }
}
