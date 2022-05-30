using System.ComponentModel.DataAnnotations.Schema;

namespace DataModel.Models.Entities
{
    public class StoreHeader
    {
        [Column("storeHeaderId")]
        public int id { get; set; }
        public string itemNoInExpenditureRegister { get; set; }
        public string noOfEntryInTheRegisterOfIncomingGoods { get; set; }
        public string donor { get; set; }
        [ForeignKey(nameof(NotifyHeader))]
        public int notifyHeaderId { get; set; }
        public ICollection<StoreItem> StoreItems { get; set; }
    }
}
