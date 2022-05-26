using System;
using System.Linq;
using System.Text;
using DataModel.Models.DTOs;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Response
{
    public class CreateNotifyHeaderResponse : BaseResponse<int>
    {
        public CreateNotifyHeaderResponse() : base()
        {

        }
        public NotifyHeaderForCreationDto NotifyHeader { get; set; }

    }
}
