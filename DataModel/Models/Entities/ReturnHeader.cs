using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class ReturnHeader
    {
        [Column("returnHeaderId")]
        public int id { get; set; }
        public string description { get; set; }
        public string? attachments { get; set; }
        [ForeignKey(nameof(HR))]

        public int hrId { get; set; }
        public HR HR { get; set; }
        public ICollection<ReturnItem> ReturnItems { get; set; }
    }
}
