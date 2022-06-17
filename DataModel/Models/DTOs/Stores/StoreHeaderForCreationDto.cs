namespace DataModel.Models.DTOs.Stores
{
    public class StoreHeaderForCreationDto : StoreHeaderForManipulationDto
    {
        public IEnumerable<StoreItemForCreationDto>? StoreItems { get; set; }
    }
}
