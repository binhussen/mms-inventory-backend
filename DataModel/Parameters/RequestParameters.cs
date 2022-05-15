using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DataModel.Parameters
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 50;
         // [FromQuery]
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
         // [FromQuery]
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public string OrderBy { get; set; }
    }
}
