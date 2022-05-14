using DataModel.Models.Common;

namespace DataModel.Models.Entities
{
    public class NotifyHeader : BaseEntity
    {
        public int id { get; set; }
        public string weaponDescription { get; set; }
        public string attachments { get; set; }
        public ICollection<NotifyDetail> NotifyDetail { get; set; }
    }
}