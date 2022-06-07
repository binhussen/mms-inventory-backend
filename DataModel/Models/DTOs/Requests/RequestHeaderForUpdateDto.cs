namespace DataModel.Models.DTOs.Requests
{
    public class RequestHeaderForUpdateDto : RequestHeaderForManipulationDto
    {
        public IEnumerable<RequestItemForCreationDto>? RequestItems { get; set; }
    }
}
