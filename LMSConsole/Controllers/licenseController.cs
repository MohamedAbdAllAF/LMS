using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Models;

namespace LMSConsole.Controllers
{
    internal class licenseController
    {
        LMSContext context =new LMSContext();
        ExceptionHandler handler = new ExceptionHandler();

        public bool AddLocation(string location)
        {
            try
            {
                context.Locations.Add(new Location { Name = location });
                context.SaveChanges();

                Console.WriteLine(location + " Successfuly Added");
                return true;
            }
            catch (Exception ex)
            {
                handler.AddExeption(ex, "licenseController",DateTime.Now);
                return false;
            }
        }

        public bool RemoveLocation(string location)
        {
            try
            {
                var loact = context.Locations.Where(l=>l.Name==location).First();
                context.Locations.Remove(loact);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                handler.AddExeption(ex, "licenseController", DateTime.Now);
                return false;
            }
        }

        public void DisplayLocations()
        {
            var loactions = context.Locations.ToList();
            foreach (var location in loactions)
            {
                Console.WriteLine(location.Name);
            }
        }
    }
}
