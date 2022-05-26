using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Models.DTOs
{
    public class NotifyHeaderForCreationDto : NotifyHeaderForManipulationDto
    {
        public IEnumerable<NotifyItemForCreationDto>? NotifyItems { get; set; }
    }
}
