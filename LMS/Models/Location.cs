using System.Collections.Generic;

namespace LMS.Models
{
    internal class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<license> Licenses { get; set;}
    }
}
