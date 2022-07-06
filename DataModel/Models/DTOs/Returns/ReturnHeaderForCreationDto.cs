namespace DataModel.Models.DTOs.Returns
{
    public class ReturnHeaderForCreationDto : ReturnHeaderForManupulationDto
    {
        public IEnumerable<ReturnItemForCreationDto>? ReturnItems { get; set; }
    }
}
