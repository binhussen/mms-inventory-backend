namespace DataModel.Models.DTOs
{
    public class StoreHeaderForUpdateDto : StoreHeaderForManipulationDto
    {
        public IEnumerable<StoreItemForCreationDto>? StoreItems { get; set; }
    }
}

