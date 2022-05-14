using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Contracts.Models.ResponseModels.NotifyResponse
{
    public class GetNotifyHeaderResponse : ApiResponse<NotifyHeader>
    {
        public int id { get; set; }

        public List<GetNotifyHeaderResponse> items { get; set; }
    }
}