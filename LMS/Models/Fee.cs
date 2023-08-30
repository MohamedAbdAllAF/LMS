using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    internal class Fee
    {
        public int Id { get; set; }

        [ForeignKey(nameof(licenses))]
        public int LicenseId { get; set; }

        public decimal Amount { get; set; }

        public virtual license licenses { get; set; }
    }
}
