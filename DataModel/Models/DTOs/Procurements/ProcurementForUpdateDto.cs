namespace DataModel.Models.DTOs.Procurements
{
    public class ProcurementForUpdateDto : ProcurementForManipulationDto
    {
        public IEnumerable<ProcurementItemForCreationDto>? ProcurmentItems { get; set; }
    }

}

