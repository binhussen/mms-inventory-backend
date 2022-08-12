namespace DataModel.Models.DTOs.Procurements
{
    public class ProcurementDto
    {
        public int id { get; set; }
        public string refNo { get; set; }
        public DateTimeOffset date { get; set; }
        public string attachments { get; set; }
    }
}
