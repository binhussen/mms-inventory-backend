using System;
using DataModel;
using System.Linq;
using System.Text;
using Contracts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Repository.RequestHandlers
{
    public class RepositoryManager : IRepositoryManager
    {
        private MMSDbContext _repositoryContext;
        private INotifyHeader  _notifyHeaderRepository;
        private INotifyDetail _notifyDetailRepository;
        public RepositoryManager(MMSDbContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public INotifyHeader NotifyHeader
        {
            get
            {
                if (_notifyHeaderRepository == null)
                    _notifyHeaderRepository = new NotifyHeaderRepository(_repositoryContext);

                return _notifyHeaderRepository;
            }
        }

        public INotifyDetail NotifyDetail
        {
            get
            {
                if (_notifyDetailRepository == null)
                    _notifyDetailRepository = new NotifyDetailRepository(_repositoryContext);

                return _notifyDetailRepository;
            }
        }

        public Task SaveAsync() =>  _repositoryContext.SaveChangesAsync();
    }
}