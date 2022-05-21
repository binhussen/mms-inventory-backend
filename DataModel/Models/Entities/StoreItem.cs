using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class StoreItem
    {
        [Column("storeItemId")]
        public int id { get; set; }
        public string itemDescription { get; set; }
        public string model { get; set; }
        public string serialNo { get; set; }
        public string type { get; set; }
        public string storeNo { get; set; }
        public string shelfNo { get; set; }
        public string availability { get; set; }
         [ForeignKey(nameof(StoreHeader))]
        public int storeHeaderId { get; set; }
        public StoreHeader StoreHeader { get; set; }
    }
}
