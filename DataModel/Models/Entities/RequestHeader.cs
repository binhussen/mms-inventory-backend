using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class RequestHeader
    {
        [Column("requestHeaderId")]
        public int id { get; set; }
        [Required(ErrorMessage = "NotifyHeader description is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the description is 60 characters.")]
        public string description { get; set; }
        [Required(ErrorMessage = "Upload your attachment.")]
        public string? attachments { get; set; }
        [ForeignKey(nameof(HR))]
        public int hrId { get; set; }
        public HR HR { get; set; }
        public ICollection<RequestItem> RequestItems { get; set; }
    }
}
