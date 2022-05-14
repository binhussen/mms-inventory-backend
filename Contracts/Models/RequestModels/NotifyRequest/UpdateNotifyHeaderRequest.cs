using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Contracts.Models.ResponseModels.NotifyRequest
{
    public class UpdateNotifyHeaderRequest : Notifyheader
    {
        public int id { get; set; }
    }
}