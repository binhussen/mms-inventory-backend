using Contracts.Interfaces;
using DataModel;
using DataModel.Models.Entities;
using DataModel.Parameters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomer
    {
        public CustomerRepository(MMSDbContext repositoryContext) : base(repositoryContext)
        {

        }
        public void CreateCustomer(Customer customer)
        {
            Create(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
        }

        public async Task<PagedList<Customer>> GetAllCustomersAsync(CustomerParameters customerParameters, bool trackChanges)
        {
            var customer = await FindAll(trackChanges)
                        .OrderBy(c => c.name)
                       .ToListAsync();
            return PagedList<Customer>
                .ToPagedList(customer, customerParameters.PageNumber, customerParameters.PageSize);
        }

        public async Task<Customer> GetCustomerByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(e => e.id.Equals(id), trackChanges)
             .SingleOrDefaultAsync();
    }
}
