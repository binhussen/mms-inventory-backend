using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Models.DTOs
{
    public class StoreHeaderDto
    {
        public int id { get; set; }
        public string itemNoInExpenditureRegister { get; set; }
        public string noOfEntryInTheRegisterOfIncomingGoods { get; set; }
        public string donor { get; set; }
    }
}
