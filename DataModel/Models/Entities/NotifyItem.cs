using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class NotifyItem
    {
        [Column("notifyItemId")]
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string model { get; set; }
        public int quantity { get; set; }
        [ForeignKey(nameof(NotifyHeader))]
        public int notifyHeaderId { get; set; }
        public NotifyHeader NotifyHeader { get; set; }
    }
}