using Pixelart.Orders.Core.Entities;

namespace Pixelart.Orders.Services.Intefaces;
public interface ICustomerService{

    Task<Customer?> GetCustomerAsync(Guid customerId);
    Task CreateCustomerAsync(Customer customer);
}