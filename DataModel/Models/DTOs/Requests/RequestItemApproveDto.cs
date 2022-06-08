namespace DataModel.Models.DTOs.Requests
{
    public class RequestItemApproveDto
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public string model { get; set; }
        public int? quantity { get; set; }
    }
}
