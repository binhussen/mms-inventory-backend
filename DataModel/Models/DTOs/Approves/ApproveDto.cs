namespace DataModel.Models.DTOs.Approve
{
    public class ApproveDto
    {
        public int id { get; set; }
        public int approvedQuantity { get; set; }
        public int storeItemId { get; set; }
        public int requestId { get; set; }
    }
}
