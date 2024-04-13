using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    internal class Fee
    {
        public int Id { get; set; }

        [ForeignKey(nameof(licenses))]
        public int LicenseId { get; set; }

        public decimal Amount { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual license licenses { get; set; }
    }
}
