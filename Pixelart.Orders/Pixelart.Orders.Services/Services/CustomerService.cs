using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Services.Intefaces;
using Pixelart.Orders.Services.Repositories;

namespace Pixelart.Orders.Services.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateCustomerAsync(Customer customer)
    {
        await _repository.CreateAsync(customer);
    }

    public async Task<Customer?> GetCustomerAsync(Guid customerId)
    {
        return await _repository.GetAsync(customerId);
    }
}