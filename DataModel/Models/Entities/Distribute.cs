using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class Distribute
    {
        [Column("distributeId")]
        public int id { get; set; }
        [ForeignKey(nameof(Approve))]
        public int approveId { get; set; }
        public Approve Approve { get; set; }
    }
}
