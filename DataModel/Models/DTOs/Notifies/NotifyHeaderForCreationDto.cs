namespace DataModel.Models.DTOs.Notify
{
    public class NotifyHeaderForCreationDto : NotifyHeaderForManipulationDto
    {
        public IEnumerable<NotifyItemForCreationDto>? NotifyItems { get; set; }
    }
}
