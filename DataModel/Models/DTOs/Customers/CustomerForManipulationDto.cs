namespace DataModel.Models.DTOs.Customers
{
    public class CustomerForManipulationDto
    {
        public string? name { get; set; }
        public string? sex { get; set; }
        public DateTimeOffset? date { get; set; }
        public string? region { get; set; }
        public string? sub_City { get; set; }
        public string? woreda { get; set; }
        public string? homeNumber { get; set; }
        public string? bithPlace { get; set; }
        public string? birthDate { get; set; }
        public string? occupation { get; set; }
        public string? phoneNumber { get; set; }
        public string? warantiyname { get; set; }
        public string? warantiyAddress { get; set; }
        public string? warantiySubCity { get; set; }
        public string? warantiyWoreda { get; set; }
        public string? warantiyRegion { get; set; }
        public DateTimeOffset? timeLimit { get; set; }
    }
}
