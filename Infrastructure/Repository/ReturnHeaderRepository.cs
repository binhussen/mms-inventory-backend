using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ReturnHeaderRepository : RepositoryBase<ReturnHeader>, IReturnHeader
    {
        public ReturnHeaderRepository(MMSDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateReturnHeader(ReturnHeader returnHeader)
        {
            Create(returnHeader);
        }

        public void DeleteReturnHeader(ReturnHeader returnHeader)
        {
            Delete(returnHeader);
        }

        public async Task<PagedList<ReturnHeader>> GetAllReturnHeadersAsync(ReturnHeaderParameters returnHeaderParameters, bool trackChanges)
        {
            var returnHeader = await FindAll(trackChanges)
                  .OrderBy(c => c.id)
                  .ToListAsync();
            return PagedList<ReturnHeader>
                  .ToPagedList(returnHeader, returnHeaderParameters.PageNumber, returnHeaderParameters.PageSize);

        }

        public async Task<ReturnHeader> GetReturnHeaderAsync(int returnHeaderId, bool trackChanges) =>
             await FindByCondition(c => c.id.Equals(returnHeaderId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
