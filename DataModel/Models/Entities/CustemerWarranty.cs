using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class CustomerWarranty
    {
        [Column("warrantyId")]
        public int id { get; set; }
        public string? warantiyname { get; set; }
        public string? warantiyAddress { get; set; }
        public string? warantiySubCity { get; set; }
        public string? warantiyWoreda { get; set; }
        public string? warantiyRegion { get; set; }
        [ForeignKey(nameof(Customer))]
        public int customerId { get; set; }
        public Customer Customer { get; set; }
    }
}
