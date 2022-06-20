using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class Customer
    {
        [Column("customerId")]
        public int id { get; set; }
        public string? name { get; set; }
        public string? sex { get; set; }
        public string? region { get; set; }
        public string? subCity { get; set; }
        public string? woreda { get; set; }
        public string? homeNumber { get; set; }
        public string? bithPlace { get; set; }
        public string? birthDate { get; set; }
        public string? occupation { get; set; }
        public string? phoneNumber { get; set; }
        public DateTimeOffset? timeLimit { get; set; }
        public ICollection<CustomerWarranty> CustemerWarranties { get; set; }
    }
}
