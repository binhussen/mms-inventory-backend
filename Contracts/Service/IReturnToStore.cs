using DataModel.Models.Entities;

namespace Contracts.Service
{
    public interface IReturnToStore
    {
        Task ExecuteAsync(string rtnNumber, StoreItem storeItem, int quantity, string doneBy);
    }
}
