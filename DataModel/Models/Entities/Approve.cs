using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class Approve
    {
        [Column("approveId")]
        public int? id { get; set; }
        public int approvedQuantity { get; set; }
        [ForeignKey(nameof(StoreItem))]
        public int storeItemId { get; set; }
        public StoreItem StoreItem { get; set; }
        [ForeignKey(nameof(RequestItem))]
        public int requestId { get; set; }
        public RequestItem RequestItem { get; set; }

    }
}
