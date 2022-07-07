using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class ReturnItem
    {
        [Column("returnItemId")]
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public string status { get; set; } = "Pending";
        public int requestedQuantity { get; set; }
        public int approvedQuantity { get; set; } = 0;
        public string? attachments { get; set; }
        [ForeignKey(nameof(ReturnHeader))]
        public int returnHeaderId { get; set; }
        public ReturnHeader ReturnHeader { get; set; }
        //[ForeignKey(nameof(Distribute))]
        //public int distributeId { get; set; }
        //public Distribute Distribute { get; set; }
    }
}
