using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    internal class license
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerID{ get; set; }

        [ForeignKey(nameof(Agent))]
        public int? AgentID { get; set; }

        [ForeignKey(nameof(Locat))]
        public int LocationId { get; set; }

        public string PlotNumber { get; set; }

        public string Work { get; set; }

        public decimal? Fees { get; set; }

        public string LicenseNumber { get; set; }

        [ForeignKey(nameof(ValStat))]
        public int? ValidityStatId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EntryDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? InitialSupplyDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FinalPaymentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExaminationFeeDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? FeesPaymentDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? SignatureDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReceiveDate { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastUpdate { get; set; }

        public virtual User Owner { get; set; }
        public virtual User Agent { get; set; }
        public virtual Location Locat { get; set; }
        public virtual ValidityStatment ValStat { get; set; }
        public virtual ICollection<Fee> FeesObj { get; set; }
        public virtual ICollection<AttachedFiles> AttachedFiles { get; set; }
    }
}
