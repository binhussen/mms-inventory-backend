using DataModel.Models.DTOs.Warranty;

namespace DataModel.Models.DTOs.Customers
{
    public class CustomerForCreationDto : CustomerForManipulationDto
    {
        public IEnumerable<WarrantiyForCreationDto>? CustomerWarranties { get; set; }
    }
}
