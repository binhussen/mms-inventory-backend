namespace DataModel.Models.DTOs
{
    public class NotifyHeaderForCreationDto : NotifyHeaderForManipulationDto
    {
        public IEnumerable<NotifyItemForCreationDto>? NotifyItems { get; set; }
    }
}
