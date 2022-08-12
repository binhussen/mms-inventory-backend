namespace DataModel.Models.DTOs.Procurements
{
    public class ProcurementForCreationDto : ProcurementForManipulationDto
    {
        public IEnumerable<ProcurementItemForCreationDto>? ProcurmentItems { get; set; }
    }
}
