using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Parameters
{
    public class NotifyItemParameters : RequestParameters
    {
        public NotifyItemParameters()
        {
            OrderBy = "Name";
        }

        public int quantity { get; set; }

        //public string SearchTerm { get; set; }
    }
}
