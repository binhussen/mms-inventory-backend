namespace Contracts.Models
{
    public class NotifyHeader
    {
        public string weaponDescription { get; set; }
        public string attachments { get; set; }
        public ICollection<NotifyDetail> NotifyDetail { get; set; }
    }
}