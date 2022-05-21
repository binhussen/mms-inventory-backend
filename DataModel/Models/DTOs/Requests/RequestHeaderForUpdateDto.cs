using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Models.DTOs.Requests
{
    public class RequestHeaderForUpdateDto : RequestHeaderForManipulationDto
    {
        public IEnumerable<RequestItemForCreationDto> RequestItems { get; set; }
    }
}
