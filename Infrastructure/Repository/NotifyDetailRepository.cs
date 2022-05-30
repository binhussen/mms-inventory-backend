using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class NotifyItemRepository : RepositoryBase<NotifyItem>, INotifyItem
    {
        public NotifyItemRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateNotifyItemForNotifyHeader(int notifyHeaderId, NotifyItem notifyItem)
        {
            notifyItem.notifyHeaderId = notifyHeaderId;
            Create(notifyItem);
        }

        public void DeleteNotifyItem(NotifyItem notifyItem)
        {
            Delete(notifyItem);
        }

        public async Task<NotifyItem> GetNotifyItemAsync(int notifyHeaderId, int id, bool trackChanges) =>
         await FindByCondition(e => e.notifyHeaderId.Equals(notifyHeaderId) && e.id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<PagedList<NotifyItem>> GetNotifyItemsAsync(int notifyHeaderId, NotifyItemParameters notifyItemParameters, bool trackChanges)
        {
            var notifyItems = await FindByCondition(e => e.notifyHeaderId.Equals(notifyHeaderId), trackChanges)
              .OrderBy(e => e.name)
              .ToListAsync();
            return PagedList<NotifyItem>
              .ToPagedList(notifyItems, notifyItemParameters.PageNumber, notifyItemParameters.PageSize);
        }
    }
}




