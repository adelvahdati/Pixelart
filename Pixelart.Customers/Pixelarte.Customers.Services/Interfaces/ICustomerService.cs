using Pixelart.Customers.Core.Entities;

namespace Pixelart.Customers.Services.Intefraces;

public interface ICustomerService
{
    Task CreateAsync(string name,string family, string address, string zipcode, string phone, DateTime birthdate);
    Task<Customer> GetAsync(Guid customerId);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(Guid id);
    Task<List<Customer>> ListAsync(int pageIndex, int pageSize);
}