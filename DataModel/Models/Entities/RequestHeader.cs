using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class RequestHeader
    {
        [Column("requestHeaderId")]
        public int id { get; set; }
        public string description { get; set; }
        public string attachments { get; set; }
        public ICollection<RequestItem> RequestItems { get; set; }
    }
}
