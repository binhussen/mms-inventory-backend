using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class NotifyHeader
    {
        [Column("notifyHeaderId")]
        public int id { get; set; }
        [Required(ErrorMessage = "NotifyHeader itemDescription is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the itemDescription is 60 characters.")]
        public string itemDescription { get; set; }
        [Required(ErrorMessage = "Upload your attachment.")]
        public string? attachments { get; set; }
        public ICollection<NotifyItem> NotifyItems { get; set; }
    }
}