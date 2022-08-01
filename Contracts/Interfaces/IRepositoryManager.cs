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
        IDistribute Distribute { get; }
        ICustomer Customer { get; }
        IWarranty CustomerWarranty { get; }
        IReturnHeader ReturnHeader { get; }
        IReturnItem ReturnItem { get; }
        IHr Hrs { get; }
        Task SaveAsync();
    }
}
