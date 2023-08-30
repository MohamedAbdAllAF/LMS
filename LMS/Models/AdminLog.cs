using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    internal class AdminLog
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        [ForeignKey(nameof(Admin))]
        public int AdminId { get; set; }

        public string TableName { get; set; }

        public string columnName { get; set; }

        public int RecordId { get; set; }

        public string Event { get; set; }

        public Admin Admin { get; set; }
    }
}
