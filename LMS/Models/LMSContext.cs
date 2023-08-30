using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    internal class LMSContext :DbContext
    {
        //Accessing The Connection String
        //public LMSContext() : base("DBConnection") { }
        public LMSContext() : base("Testing") { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<license> Licenses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ValidityStatment> validityStatments { get; set; }

    }
}
