namespace DataModel.Models.DTOs.Requests
{
    public class RequestItemStatus
    {
        public string status { get; set; }
        public int approvedQuantity { get; set; }
        public string? attachments { get; set; }
    }
}
