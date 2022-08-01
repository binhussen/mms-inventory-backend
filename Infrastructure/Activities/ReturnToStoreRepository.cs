using Contracts.Interfaces;
using Contracts.Service;
using DataModel.Models.Entities;

namespace Infrastructure.Activities
{
    public class ReturnToStoreRepository : IReturnToStore
    {
        private readonly IStoreItem returnToStoreRepository;

        public async Task ExecuteAsync(string rtnNumber, StoreItem storeItem, int quantity, string doneBy)
        {
            //we also need to increase the quantity
            storeItem.quantity += quantity;
            await this.returnToStoreRepository.UpdateStoreAsync(storeItem);
        }
    }
}
