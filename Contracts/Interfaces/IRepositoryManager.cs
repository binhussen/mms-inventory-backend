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
        IApprove Approve { get; }
        ICustomer Customer { get; }
        //int UpdateRequestItemStatus(string model, string RequestStatus);
        //int UpdateRequestItemStatus(int requestItemId);
        Task SaveAsync();
    }
}
