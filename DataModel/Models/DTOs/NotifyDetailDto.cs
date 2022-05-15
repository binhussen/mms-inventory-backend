using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Models.DTOs
{
    public class NotifyDetailDto
    {
        public int id { get; set; }
        public string weaponType { get; set; }
        public string weaponName { get; set; }
        public int quantity { get; set; }
    }
}
