using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class RequestHeader
    {
        [Column("requestHeaderId")]
        public int id { get; set; }
        public string requestStatus { get; set; }
        public string description { get; set; }
        public string attachments { get; set; }
        public ICollection<RequestItem> RequestItems { get; set; }
    }
}
