namespace DataModel.Models.DTOs.Returns
{
    public class ReturnHeaderForUpdateDto : ReturnHeaderForManupulationDto
    {
        public IEnumerable<ReturnItemForCreationDto>? ReturnItems { get; set; }
    }
}
