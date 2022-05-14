using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Contracts.Models.RequestModels.NotifyRequest
{
    public class UpdateNotifyHeaderRequest : NotifyHeader
    {
        public int id { get; set; }
    }
}