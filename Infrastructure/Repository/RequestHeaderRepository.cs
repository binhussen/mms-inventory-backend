using System;
using DataModel;
using System.Linq;
using System.Text;
using Contracts.Interfaces;
using DataModel.Parameters;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class RequestHeaderRepository : RepositoryBase<RequestHeader>, IRequestHeader
    {
        public RequestHeaderRepository(MMSDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateRequestHeader(RequestHeader requestHeader)
        {
            Create(requestHeader);
        }

        public void DeleteRequestHeader(RequestHeader requestHeader)
        {
             Delete(requestHeader);
        }
        public async Task<PagedList<RequestHeader>> GetAllRequestHeadersAsync(RequestHeaderParameters requestHeaderParameters, bool trackChanges)
        {
            var requestHeader = await FindAll(trackChanges)
                   .OrderBy(c => c.id)
                   .ToListAsync();
            return PagedList<RequestHeader>
                  .ToPagedList(requestHeader, requestHeaderParameters.PageNumber, requestHeaderParameters.PageSize);
        }

        public async Task<RequestHeader> GetRequestHeaderAsync(int requestHeaderId, bool trackChanges) =>
            await FindByCondition(c => c.id.Equals(requestHeaderId), trackChanges)
            .SingleOrDefaultAsync();
    }
}
