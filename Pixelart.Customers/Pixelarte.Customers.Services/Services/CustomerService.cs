using Pixelart.Customers.Core.Entities;
using Pixelart.Customers.Core.Valueobjects;
using Pixelart.Customers.Services.Intefraces;
using Pixelart.Customers.Services.Repository;

namespace Pixelart.Customers.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(string name, string family, string address, string zipcode, string phone, DateTime birthdate)
    {
        var customerName = new Name() {Value = name};
        var customerFamily = Family.Create(family);
        var customer = Customer.Create(customerName,customerFamily,address,zipcode,phone,birthdate);
        await _repository.CreateAsync(customer);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<Customer> GetAsync(Guid customerId)
    {
        return await _repository.GetAsync(customerId);
    }

    public async Task<List<Customer>> ListAsync(int pageIndex, int pageSize)
    {
        return await _repository.ListAsync(pageIndex,pageSize);
    }

    public async Task UpdateAsync(Customer customer)
    {
        await _repository.UpdateAsync(customer);
    }
}
