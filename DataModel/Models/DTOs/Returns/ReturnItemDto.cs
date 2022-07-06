namespace DataModel.Models.DTOs.Returns
{
    public class ReturnItemDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public string status { get; set; }
        public int requestedQuantity { get; set; }
        public int approvedQuantity { get; set; }
        public string? attachments { get; set; }
    }
}
