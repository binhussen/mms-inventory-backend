using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class ProcurementItem
    {
        [Column("procurementItemId")]
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string unitMeasure { get; set; }
        public int quantity { get; set; }
        public int totalQuantity { get; set; }
        public string? explanation { get; set; }
        [ForeignKey(nameof(Procurement))]
        public int procurementId { get; set; }
        public Procurement Procurement { get; set; }

    }
}
