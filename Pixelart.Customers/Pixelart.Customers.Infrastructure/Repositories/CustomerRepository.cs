using Microsoft.EntityFrameworkCore;
using Pixelaret.Customers.Infrastructure.Data;
using Pixelart.Customers.Core.Entities;
using Pixelart.Customers.Infrastructure.Data;
using Pixelart.Customers.Services.Repository;

namespace Pixelaret.Customers.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CustomerRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Customer customer)
    {
        await _dbContext.Customers.AddAsync(CustomerEntity.Create(customer));
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var customer = await _dbContext.Customers.FindAsync(id);
        if(customer == null)
            return;

        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Customer?> GetAsync(Guid id)
    {
        var customerEntity = await _dbContext.Customers.FindAsync(id);
        if(customerEntity == null)
            return null;
        
        return customerEntity.ToCustomer();
        
    }

    public async Task<List<Customer>> ListAsync(int pageIndex, int pageSize)
    {
        int n;
        n= pageIndex > 1? (pageIndex-1)* pageSize : 0;
        var customerEntities = await _dbContext.Customers.OrderBy(customer=> customer.Family)
                            .Skip(n)
                            .Take(pageSize)
                            .ToListAsync();

        if(customerEntities == null)
            return new List<Customer>();
        
        return customerEntities
                    .Select(customerEntity=> customerEntity.ToCustomer())
                    .ToList();

    }

    public async Task UpdateAsync(Customer customer)
    {
        _dbContext.Customers.Update(CustomerEntity.Create(customer));
        await _dbContext.SaveChangesAsync();
    }
}
