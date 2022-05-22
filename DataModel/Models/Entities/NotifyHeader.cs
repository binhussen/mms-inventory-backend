using DataModel.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class NotifyHeader
    {
        [Column("notifyHeaderId")]
        public int id { get; set; }
        public string itemDescription { get; set; }
        public string attachments { get; set; }
        public ICollection<NotifyItem> NotifyItems { get; set; }
    }
}