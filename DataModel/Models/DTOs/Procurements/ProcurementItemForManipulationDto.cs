namespace DataModel.Models.DTOs.Procurements
{
    public class ProcurementItemForManipulationDto
    {
        public string Name { get; set; }
        public string type { get; set; }
        public string unitMeasure { get; set; }
        public int quantity { get; set; }
        public int totalQuantity { get; set; }
        public string explanation { get; set; }
    }
}
