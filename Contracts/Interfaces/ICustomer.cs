using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface ICustomer
    {
        Task<PagedList<Customer>> GetAllCustomersAsync(CustomerParameters customerParameters, bool trackChanges);
        Task<Customer> GetCustomerByIdAsync(int id, bool trackChanges);
        void CreateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
