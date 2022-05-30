using DataModel.Enums;

namespace DataModel.Models.DTOs.Requests
{
    public class RequestItemForManipulationDto
    {
        public string name { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public int quantity { get; set; }
        public RequestStatuses status { get; set; }
    }
}
