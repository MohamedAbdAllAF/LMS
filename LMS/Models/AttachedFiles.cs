using System.ComponentModel.DataAnnotations.Schema;

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
