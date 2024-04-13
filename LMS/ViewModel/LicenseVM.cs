using System;
using System.Collections.Generic;

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
        public List<(int id, string FileName, string Extension, byte[] Data)> fileList { get; set; }
        public DateTime? LEntryDate { get; set; }
        public DateTime? LExaminationFeeDate { get; set; }
        public DateTime? LInitialSupplyDate { get; set; }
        public DateTime? LFinalPaymentDate { get; set; }
        public DateTime? LFeesPaymentDate { get; set; }
        public DateTime? LSignatureDate { get; set; }
        public DateTime? LReceiveDate { get; set; }
        public DateTime? VEntryDate { get; set; }
        public DateTime? VInitialSupplyDate { get; set; }
        public DateTime? VValidatySupplyDate { get; set; }
        public DateTime? VReceiveDate { get; set; }
        public DateTime? LastUptate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
