using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS;
using LMSConsole.Controllers;

namespace LMSConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            licenseController licenControl = new licenseController();

            licenControl.DisplayLocations();
            Console.WriteLine("----------------------------------");
            licenControl.RemoveLocation("Elsrouq");
            licenControl.RemoveLocation("Elsrouq");
            licenControl.RemoveLocation("Elsrouq");



            Console.WriteLine("\n\n################ Proram Finshed ################");
            Console.ReadKey();
        }
    }
}
