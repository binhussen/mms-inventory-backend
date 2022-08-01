using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class HrRepository : RepositoryBase<HR>, IHr
    {
        public HrRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task<PagedList<HR>> GetAllHrsAsync(HrParameters hrParameters, bool trackChanges)
        {
            var hr = await FindAll(trackChanges)
                      .OrderBy(c => c.firstName)
                     .ToListAsync();
            return PagedList<HR>
                .ToPagedList(hr, hrParameters.PageNumber, hrParameters.PageSize);
        }
        public async Task<HR> GetHrByIdAsync(int id, bool trackChanges) =>
         await FindByCondition(e => e.id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();


        public void CreateHr(HR hr)
        {
            Create(hr);
        }

        public void DeleteHr(HR hr)
        {
            Delete(hr);
        }
    }
}
