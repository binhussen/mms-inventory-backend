namespace DataModel.Models.DTOs.Requests
{
    public class RequestHeaderForCreationDto : RequestHeaderForManipulationDto
    {
        public IEnumerable<RequestItemForCreationDto>? RequestItems { get; set; }
    }
}

