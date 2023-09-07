using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.ViewModel
{
    internal class LicenseVM
    {
        public string OwnarNationalId { get; set; }
        public string OwnarName { get; set; }
        public string AgentNationalId { get; set; }
        public string AgentName { get; set; }
        public string Location { get; set; }
        public string PlotNumber { get; set; }
        public string Work { get; set; }
        public decimal? Fees { get; set; }
        public string LicenseNumber { get; set; }
        public string Notes { get; set; }
        public DateTime? LEntryDate { get; set; }
        public DateTime? LExaminationFeeDate { get; set; }
        public DateTime? LFeesPaymentDate { get; set; }
        public DateTime? LSignatureDate { get; set; }
        public DateTime? LReceiveDate { get; set; }
        public DateTime? VEntryDate { get; set; }
        public DateTime? VInitialSupplyDate { get; set; }
        public DateTime? VValidatySupplyDate { get; set; }
        public DateTime? VReceiveDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
