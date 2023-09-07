using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace LMS.ViewModel
{
    internal class SearchVM
    {
        public int LicenseId { get; set; }
        public string OwnerNationalId { get; set; }
        public string OwnerName { get; set; }
        public string AgentNationalId { get; set; }
        public string AgentName { get; set;}
        public string Location { get; set; }
        public string PlotNumber { get; set; }
    }
}
