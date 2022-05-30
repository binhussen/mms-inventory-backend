using DataModel.Enums;
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
        public int quantity { get; set; }
        public RequestStatuses status { get; set; }
        [ForeignKey(nameof(RequestHeader))]
        public int requestHeaderId { get; set; }
        public RequestHeader RequestHeader { get; set; }
    }
}
