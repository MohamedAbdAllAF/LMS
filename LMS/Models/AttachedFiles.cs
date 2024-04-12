using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    internal class AttachedFiles
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public byte[] FileData { get; set; }

        [ForeignKey(nameof(License))]
        public int LicenseId { get; set; }
        public virtual license License { get; set; }
    }
}
