using DataModel.Models.Common;

namespace DataModel.Models.Entities
{
    public class NotifyDetail : BaseEntity
    {
        public int id { get; set; }
        public string weaponType { get; set; }
        public string weaponName { get; set; }
        public int quantity { get; set; }
        public int notifyHeaderId { get; set; }
    }
}