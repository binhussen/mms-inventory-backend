using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class WarrantyRepository : RepositoryBase<CustomerWarranty>, IWarranty
    {
        public WarrantyRepository(MMSDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public void CreateCustomerWarrantyForCustomer(int customerId, CustomerWarranty customerWarranty)
        {
            customerWarranty.customerId = customerId;
            Create(customerWarranty);
        }

        public void DeleteCustomerWarranty(CustomerWarranty customerWarranty)
        {
            Delete(customerWarranty);
        }

        public async Task<CustomerWarranty> GetCustomerWarrantyAsync(int customerId, int id, bool trackChanges) =>
                            await FindByCondition(e => e.customerId.Equals(customerId) && e.id.Equals(id), trackChanges)
                             .SingleOrDefaultAsync();

        public async Task<PagedList<CustomerWarranty>> GetCustomerWarrantysAsync(int customerId, CustomerWarrantyParameters customerWarrantyParameters, bool trackChanges)
        {
            var CustomerWarrantys = await FindByCondition(e => e.customerId.Equals(customerId), trackChanges)
             .OrderBy(e => e.warantiyname)
             .ToListAsync();
            return PagedList<CustomerWarranty>
              .ToPagedList(CustomerWarrantys, customerWarrantyParameters.PageNumber, customerWarrantyParameters.PageSize);
        }
    }
}
