using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Models.DTOs.Requests
{
    public class RequestItemDto
    {
        public int id { get; set; }
        public string weaponName { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public int weaponQuantity { get; set; }
    }
}
