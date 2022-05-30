namespace DataModel.Models.DTOs
{
    public class StoreHeaderForCreationDto : StoreHeaderForManipulationDto
    {
        public IEnumerable<StoreItemForCreationDto> StoreItems { get; set; }
    }
}
