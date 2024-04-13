using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
