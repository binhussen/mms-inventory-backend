using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Models.ResponseModels
{
    public class GetNotifyDeatilResponse : ApiResponse<NotifyDetail>
    {
        public int totalCount { get; set; }

        public List<NotifyDetail> items { get; set; }
    }
}