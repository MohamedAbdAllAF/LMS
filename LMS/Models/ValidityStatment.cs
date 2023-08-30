using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    internal class ValidityStatment
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EntryDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? InitialSupplyDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ValidatySupplyDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReceiveDate { get; set; }

        public virtual ICollection<license> Licenses { get; set; }
    }
}
