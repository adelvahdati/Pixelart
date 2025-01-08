using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Infrastructure.Data;
using Pixelart.Orders.Services.Repositories;

namespace Pixelart.Orders.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Customer customer)
    {        
        await _dbContext.Customers.AddAsync(CustomerEntity.CreateFrom(customer));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Customer?> GetAsync(Guid customerId)
    {
        var customerEntity = await _dbContext.Customers.FindAsync(customerId);
        if(customerEntity == null)
            return null;
        
        return customerEntity.ToCustomer();
    }
}