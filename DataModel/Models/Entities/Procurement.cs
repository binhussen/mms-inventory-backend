using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class Procurement
    {

        [Column("procurementId")]
        public int id { get; set; }
        public string refNo { get; set; }
        public DateTimeOffset date { get; set; }
        public string attachments { get; set; }

    }
}
