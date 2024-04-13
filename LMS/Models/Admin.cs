using System.Collections.Generic;

namespace LMS.Models
{
    internal class Admin
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual ICollection<AdminLog> logs { get; set; }
    }
}
