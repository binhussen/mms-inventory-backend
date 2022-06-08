using DataModel.Enums;

namespace DataModel.Models.DTOs
{
    public class NotifyItemDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public int quantity { get; set; }
        public int remainQuantity { get; set; }
        public RequestStatuses status { get; set; }
    }
}
