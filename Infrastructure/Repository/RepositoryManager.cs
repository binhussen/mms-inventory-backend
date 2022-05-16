using System;
using DataModel;
using System.Linq;
using System.Text;
using Contracts.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infrastructure.Repository
{
    /// <summary>
    /// The repository manager.
    /// </summary>
    public class RepositoryManager : IRepositoryManager
    {
        private readonly MMSDbContext _repositoryContext;
        private INotifyHeader  _notifyHeaderRepository;
        private INotifyDetail _notifyDetailRepository;
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
        /// Gets the notify detail.
        /// </summary>
        public INotifyDetail NotifyDetail
        {
            get
            {
                if (_notifyDetailRepository == null)
                    _notifyDetailRepository = new NotifyDetailRepository(_repositoryContext);

                return _notifyDetailRepository;
            }
        }
        /// <summary>
        /// Saves the async.
        /// </summary>
        /// <returns>A Task.</returns>
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}