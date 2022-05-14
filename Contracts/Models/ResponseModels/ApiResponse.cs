using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Contracts.Models.ResponseModels
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
        }
        public ApiResponse(T data)
        {
            Succeeded = true;
            Data = data;
        }

        public bool Succeeded { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }

}