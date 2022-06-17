namespace DataModel.Models.DTOs.Stores
{
    public class StoreHeaderForUpdateDto : StoreHeaderForManipulationDto
    {
        public IEnumerable<StoreItemForCreationDto>? StoreItems { get; set; }
    }
}

