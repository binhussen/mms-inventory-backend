using Contracts.Interfaces;
using DataModel;

namespace Infrastructure.Repository
{
    /// <summary>
    /// The repository manager.
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        private readonly MMSDbContext _repositoryContext;
        private INotifyHeader _notifyHeaderRepository;
        private INotifyItem _notifyItemRepository;
        private IStoreHeader _storeHeaderRepository;
        private IStoreItem _storeItemRepository;
        private IRequestItem _requestItemRepository;
        private IRequestHeader _requestHeaderRepository;
        private IApprove _approveRepository;
        private IDistribute _distributeRepository;
        private ICustomer _customerRepository;
        private IWarranty _warrantyRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryManager"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public RepositoryManager(MMSDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        /// <summary>
        /// Gets the notify header.
        /// </summary>
        public INotifyHeader NotifyHeader
        {
            get
            {
                if (_notifyHeaderRepository == null)
                    _notifyHeaderRepository = new NotifyHeaderRepository(_repositoryContext);

                return _notifyHeaderRepository;
            }
        }

        /// <summary>
        /// Gets the notify item.
        /// </summary>
        public INotifyItem NotifyItem
        {
            get
            {
                if (_notifyItemRepository == null)
                    _notifyItemRepository = new NotifyItemRepository(_repositoryContext);

                return _notifyItemRepository;
            }
        }
        public IStoreHeader StoreHeader
        {
            get
            {
                if (_storeHeaderRepository == null)
                    _storeHeaderRepository = new StoreHeaderRepository(_repositoryContext);
                return _storeHeaderRepository;
            }
        }
        public IStoreItem StoreItem
        {
            get
            {
                if (_storeItemRepository == null)
                    _storeItemRepository = new StoreItemRepository(_repositoryContext);
                return _storeItemRepository;
            }
        }

        public IRequestHeader RequestHeader
        {
            get
            {
                if (_requestHeaderRepository == null)
                    _requestHeaderRepository = new RequestHeaderRepository(_repositoryContext);
                return _requestHeaderRepository;
            }
        }

        public IRequestItem RequestItem
        {
            get
            {
                if (_requestItemRepository == null)
                    _requestItemRepository = new RequestDetailRepository(_repositoryContext);
                return _requestItemRepository;
            }
        }
        public IApprove Approve
        {
            get
            {
                if (_approveRepository == null)
                    _approveRepository = new ApproveRepository(_repositoryContext);
                return _approveRepository;
            }
        }
        public IDistribute Distribute
        {
            get
            {
                if (_distributeRepository == null)
                    _distributeRepository = new DistributeRepository(_repositoryContext);
                return _distributeRepository;
            }
        }
        public ICustomer Customer
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_repositoryContext);
                return _customerRepository;
            }
        }

        public IWarranty CustomerWarranty
        {
            get
            {
                if (_warrantyRepository == null)
                    _warrantyRepository = new WarrantyRepository(_repositoryContext);
                return _warrantyRepository;
            }
        }

        /*public int UpdateRequestItemStatus(string model, string RequestStatus)
        {
            try
            {
                RequestItem BD = (from BDs in _repositoryContext.RequestItems
                                  where BDs.model == model
                                  select BDs).Single();

                BD.status = RequestStatus;
                _repositoryContext.RequestItems.Attach(BD);
                _repositoryContext.Entry(BD).Property(x => x.requestApprovalDate).IsModified = true;
                _repositoryContext.Entry(BD).Property(x => x.status).IsModified = true;
                return _repositoryContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }*/

        /// <summary>
        /// Saves the async.
        /// </summary>
        /// <returns>A Task.</returns>
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

        //public int UpdateRequestItemStatus(int requestItemId)
        //{
        //    try
        //    {
        //        RequestItem requestitem = (from requstitems in _repositoryContext.RequestItems
        //                                   where requstitems.id == requestItemId
        //                                   select requstitems).Single();
        //        requestitem.RequestingCompletedFlag = "C";
        //        _repositoryContext.RequestItems.Attach(requestitem);
        //        _repositoryContext.Entry(requestitem).Property(x => x.RequestingCompletedFlag).IsModified = true;
        //        return _repositoryContext.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}