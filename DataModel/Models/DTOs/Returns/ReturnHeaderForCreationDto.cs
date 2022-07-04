namespace DataModel.Models.DTOs.Returns
{
    public class ReturnHeaderForCreationDto
    {
        public IEnumerable<ReturnItemForCreationDto>? ReturnItems { get; set; }
    }
}
