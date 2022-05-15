using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Parameters
{
    public class NotifyDetailParameters : RequestParameters
    {
        public NotifyDetailParameters()
        {
            OrderBy = "Name";
        }

        public int quantity { get; set; }

        //public string SearchTerm { get; set; }
    }
}
