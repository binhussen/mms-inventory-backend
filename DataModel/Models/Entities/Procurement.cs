using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class Procurement
    {

        [Column("procurementId")]
        public int id { get; set; }
        public string description { get; set; }
        public string attachments { get; set; }
        public ICollection<ProcurementItem> ProcurementItems { get; set; }

    }
}
