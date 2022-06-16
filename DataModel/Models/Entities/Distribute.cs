using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.Entities
{
    public class Distribute
    {
        [Column("distributeId")]
        public int id { get; set; }
        [ForeignKey(nameof(Customer))]
        public int userId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey(nameof(Approve))]
        public int approveId { get; set; }
        public Approve Approve { get; set; }

        /*[ForeignKey(nameof(RequestItem))]
        public int RequestId { get; set; }
        public RequestItem RequestItem { get; set; }*/

        /*[ForeignKey(nameof(StoreItem))]
        public int StoreId { get; set; }
        public StoreItem StoreItem { get; set; } */   
    }
}
