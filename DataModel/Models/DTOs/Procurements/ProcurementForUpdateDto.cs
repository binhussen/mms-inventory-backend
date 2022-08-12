namespace DataModel.Models.DTOs.Procurements
{
    public class ProcurementForUpdateDto
    {
        public IEnumerable<ProcurementItemForCreationDto>? ProcurmentItems { get; set; }
    }
}
