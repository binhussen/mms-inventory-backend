namespace DataModel.Parameters
{
    public class StoreItemParameters : RequestParameters
    {
        public uint MinQuantity { get; set; }
        public uint MaxQuantity { get; set; } = int.MaxValue;

        public bool ValidQuantityRange => MaxQuantity > MinQuantity;

        public string? SearchTerm { get; set; }
    }
}
