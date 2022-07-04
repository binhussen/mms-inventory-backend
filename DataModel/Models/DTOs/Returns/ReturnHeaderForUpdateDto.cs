namespace DataModel.Models.DTOs.Returns
{
    public class ReturnHeaderForUpdateDto
    {
        public IEnumerable<ReturnItemForCreationDto>? ReturnItems { get; set; }
    }
}
