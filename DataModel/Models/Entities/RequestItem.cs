using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class RequestItem
    {
        [Column("requestItemId")]
        public int id { get; set; }
        public string weaponName { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public int weaponQuantity { get; set; }
        [ForeignKey(nameof(RequestHeader))]
        public int requestHeaderId { get; set; }
        public RequestHeader RequestHeader { get; set; }
    }
}
