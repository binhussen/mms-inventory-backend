using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Contracts.Models.ResponseModels.NotifyResponse
{
    public class GetNotifyHeaderRequest : ApiResponse<NotifyHeader>
    {
        public int id { get; set; }

        public List<GetNotifyHeaderRequest> items { get; set; }
    }
}