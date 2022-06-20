using DataModel.Models.Entities;
using DataModel.Parameters;

namespace Contracts.Interfaces
{
    public interface IWarranty
    {
        Task<PagedList<CustomerWarranty>> GetCustomerWarrantysAsync(int customerId, CustomerWarrantyParameters customerWarrantyParameters, bool trackChanges);
        Task<CustomerWarranty> GetCustomerWarrantyAsync(int customerId, int id, bool trackChanges);
        void CreateCustomerWarrantyForCustomer(int customerId, CustomerWarranty customerWarranty);
        void DeleteCustomerWarranty(CustomerWarranty customerWarranty);
    }
}
