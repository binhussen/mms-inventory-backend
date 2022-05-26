using System;
using System.Linq;
using System.Text;
using DataModel.Response;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;

namespace DataModel.Models.DTOs
{
    public class NotifyHeaderDto : CreateNotifyHeaderResponse
    {
        public int id { get; set; }
        public string itemDescription { get; set; }
        public string attachments { get; set; }
    }
}
