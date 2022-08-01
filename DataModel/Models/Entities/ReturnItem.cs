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
        public int Quantity { get; set; }
        [ForeignKey(nameof(ReturnHeader))]
        public int returnHeaderId { get; set; }
        public ReturnHeader ReturnHeader { get; set; }
    }
}
