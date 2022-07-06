using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class Distribute
    {
        [Column("distributeId")]
        public int id { get; set; }
        [ForeignKey(nameof(Customer))]
        public int userId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey(nameof(Approve))]
        public int approveId { get; set; }
        public Approve Approve { get; set; }

        /*[ForeignKey(nameof(RequestItem))]
        public int RequestId { get; set; }
        public RequestItem RequestItem { get; set; }*/

        /*[ForeignKey(nameof(StoreItem))]
        public int StoreId { get; set; }
        public StoreItem StoreItem { get; set; } */
    }
}
