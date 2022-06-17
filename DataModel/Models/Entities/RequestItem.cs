using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class RequestItem
    {
        [Column("requestItemId")]
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public string status { get; set; } = "P";
        public int requestedQuantity { get; set; }
        public int approvedQuantity { get; set; }
        [ForeignKey(nameof(RequestHeader))]
        public int requestHeaderId { get; set; }
        public RequestHeader RequestHeader { get; set; }
        //public string RequestingCompletedFlag { get; set; }
    }
}
