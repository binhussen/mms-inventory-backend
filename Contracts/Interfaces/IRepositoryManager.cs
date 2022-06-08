namespace Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        INotifyHeader NotifyHeader { get; }
        INotifyItem NotifyItem { get; }
        IStoreHeader StoreHeader { get; }
        IStoreItem StoreItem { get; }
        IRequestHeader RequestHeader { get; }
        IRequestItem RequestItem { get; }
        Task SaveAsync();
        int UpdateRequestItemStatus(string model, string RequestStatus);
    }
}
