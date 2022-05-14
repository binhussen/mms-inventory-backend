using DataModel.Models.common;
using System.Collections.Generic;

namespace DataModel.Models.Common
{
    public class ResponseModel<T>
    {
        public List<T> Data { get; set; }
        public bool Success { get; set; }
        public ErrorModel Error { get; set; }
        public int TotalCount { get; set; }
    }
}
