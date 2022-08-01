using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class NotifyItem
    {
        [Column("notifyItemId")]
        public int id { get; set; }
        [Required(ErrorMessage = "NotifyItem type is a required field.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Name is 40 characters.")]
        public string type { get; set; }
        [Required(ErrorMessage = "NotifyItem name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string name { get; set; }
        [Required(ErrorMessage = "NotifyItem model is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string model { get; set; }
        [Required(ErrorMessage = "quantity is a required field.")]
        [Range(1, 2000)]
        public int quantity { get; set; }
        [ForeignKey(nameof(NotifyHeader))]
        public int notifyHeaderId { get; set; }
        public NotifyHeader NotifyHeader { get; set; }
    }
}