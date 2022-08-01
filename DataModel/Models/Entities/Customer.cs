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
        public string? birthPlace { get; set; }
        public DateTimeOffset? birthDate { get; set; }
        public string? occupation { get; set; }
        public string? phoneNumber { get; set; }
        public DateTimeOffset? timeLimit { get; set; }
        [ForeignKey(nameof(HR))]

        public int hrId { get; set; }
        public HR HR { get; set; }
        public ICollection<CustomerWarranty> CustomerWarranties { get; set; }
    }
}
