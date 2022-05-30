namespace DataModel.Models.DTOs
{
    public class NotifyHeaderForUpdateDto : NotifyHeaderForManipulationDto
    {
        public IEnumerable<NotifyItemForCreationDto>? NotifyItems { get; set; }
    }

}
