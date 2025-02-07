using Pixelart.Customers.Core.Entities;

namespace Pixelart.Customers.Services.Repository;

public interface ICustomerRepository
{
    Task CreateAsync(Customer customer);
    Task<Customer> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(Customer customer);
    Task<List<Customer>> ListAsync(int pageIndex, int pageSize);    
}