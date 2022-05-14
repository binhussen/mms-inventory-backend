using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Models.Common
{
    public class NotifyDetialParameters : RequestParameters
    {
        public NotifyDetialParameters()
        {
            OrderBy = "Name";
        }

        public int Status { get; set; }

        public string SearchTerm { get; set; }
    }
}
