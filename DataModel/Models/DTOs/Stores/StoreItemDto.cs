namespace DataModel.Models.DTOs.Stores
{
    public class StoreItemDto
    {
        public int id { get; set; }
        public string itemDescription { get; set; }
        public string model { get; set; }
        public string serialNo { get; set; }
        public string type { get; set; }
        public string storeNo { get; set; }
        public string shelfNo { get; set; }
        public bool availability { get; set; } = true;
        public int quantity { get; set; }
        public int availableQuantity { get; set; }
    }
}
