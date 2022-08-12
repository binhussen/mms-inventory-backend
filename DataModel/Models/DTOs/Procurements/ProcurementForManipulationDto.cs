namespace DataModel.Models.DTOs.Procurements
{
    public class ProcurementForManipulationDto
    {
        public string refNo { get; set; }
        public DateTimeOffset date { get; set; }
        public string attachments { get; set; }
    }
}
