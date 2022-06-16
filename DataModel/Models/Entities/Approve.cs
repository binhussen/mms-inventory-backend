using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Entities
{
    public class Approve
    {
        [Column("approveId")]
        public int? id { get; set; }
        public int approvedQuantity { get; set; }
        [ForeignKey(nameof(StoreItem))]
        public int storeId { get; set; }
        public StoreItem StoreItem { get; set; }
        [ForeignKey(nameof(RequestItem))]
        public int requestId { get; set; }
        public RequestItem RequestItem { get; set; }

    }
}
