using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS.Models
{
    internal class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NationalId { get; set; }

        [InverseProperty(nameof(license.Owner))]
        public virtual ICollection<license> OwnerLicenses { get; set;}
        [InverseProperty(nameof(license.Agent))]
        public virtual ICollection<license> AgnetLicenses { get; set; }
    }
}
