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
        [Column("ApproveId")]
        public int Id { get; set; }
        public int ApprovedQuantity { get; set; }
        [ForeignKey(nameof(StoreItem))]
        public int StoreId { get; set; }
        public StoreItem StoreItem { get; set; }
        [ForeignKey(nameof(RequestItem))]
        public int RequestId { get; set; }
        public RequestItem RequestItem { get; set; }

    }
}
