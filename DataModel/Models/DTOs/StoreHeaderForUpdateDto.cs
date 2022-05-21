using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Models.DTOs
{
    public class StoreHeaderForUpdateDto : StoreHeaderForManipulationDto
    {
        public IEnumerable<StoreItemForCreationDto>? StoreItems { get; set; }
    }
}

