using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Contracts.Models.ResponseModels.NotifyResponse
{
    public class GetNotifyDetailResponse : ApiResponse<NotifyDetail>
    {
        public int totalCount { get; set; }

        public List<NotifyDetail> items { get; set; }
    }
}