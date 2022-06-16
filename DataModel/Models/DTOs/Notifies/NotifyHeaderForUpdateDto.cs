namespace DataModel.Models.DTOs.Notify
{
    public class NotifyHeaderForUpdateDto : NotifyHeaderForManipulationDto
    {
        public IEnumerable<NotifyItemForCreationDto>? NotifyItems { get; set; }
    }

}
