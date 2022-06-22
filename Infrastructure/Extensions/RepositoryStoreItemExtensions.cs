using DataModel.Models.Entities;

namespace Infrastructure.Extensions
{
    public static class RepositoryStoreItemExtensions
    {
        public static IQueryable<StoreItem> FilterStoreItems(this IQueryable<StoreItem> storeItems, uint minQuantity, uint maxQuantity) =>
            storeItems.Where(e => (e.quantity >= minQuantity && e.quantity <= maxQuantity));
        public static IQueryable<StoreItem> Search(this IQueryable<StoreItem> storeItems, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return storeItems;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return storeItems.Where(e => e.model.ToLower().Contains(lowerCaseTerm) ||
                                        e.itemDescription.ToLower().Contains(lowerCaseTerm) ||
                                        e.serialNo.ToLower().Contains(lowerCaseTerm) ||
                                        e.shelfNo.ToLower().Contains(lowerCaseTerm) ||
                                        e.storeNo.ToLower().Contains(lowerCaseTerm) ||
                                        e.type.ToLower().Contains(lowerCaseTerm));

        }
    }
}
