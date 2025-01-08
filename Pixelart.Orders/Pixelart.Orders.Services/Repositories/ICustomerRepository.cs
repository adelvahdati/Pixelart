using Pixelart.Orders.Core.Entities;

namespace Pixelart.Orders.Services.Repositories;
public interface ICustomerRepository
{
    Task CreateAsync(Customer customer);
    Task<Customer?> GetAsync(Guid customerId);    
}