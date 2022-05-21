using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DataModel.Models.DTOs
{
    public class StoreHeaderForManipulationDto
    {
        public string itemNoInExpenditureRegister { get; set; }
        public string noOfEntryInTheRegisterOfIncomingGoods { get; set; }
        public int donor { get; set; }
    }
}
