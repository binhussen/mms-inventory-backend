using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Models.ResponseModels
{
    public class GetNotifyHeaderRequest : ApiResponse<NotifyHeader>
    {
        public int id { get; set; }

        public List<GetNotifyHeaderRequest> items { get; set; }
    }
}