using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Models.DTOs.Approve
{
    public class ApproveDto
    {
        public int id { get; set; }
        public int approvedQuantity { get; set; }
        public int storeId { get; set; }
        public int requestId { get; set; }
    }
}
