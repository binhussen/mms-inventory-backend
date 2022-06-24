namespace DataModel.Models.DTOs.Requests
{
    public class RequestItemDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public int requestedQuantity { get; set; }
        public string status { get; set; }
        public int approvedQuantity { get; set; }
        public string? attachments { get; set; }
    }

}
