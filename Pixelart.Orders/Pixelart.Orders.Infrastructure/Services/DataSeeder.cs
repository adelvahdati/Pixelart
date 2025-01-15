using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Core.ValueObjects;
using Pixelart.Orders.Services.Repositories;

namespace Pixelart.Orders.Infrastructure.Services;

public class DataSeeder : IDataSeeder
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IProductRepository _productRepository;

    public DataSeeder(ICustomerRepository customerRepository, IProductRepository productRepository)
    {
        _customerRepository = customerRepository;
        _productRepository = productRepository;
    }

    public async Task SeedCustomersAsync()
    {
        var customers = new List<Customer>()
        {
            new Customer(Guid.Parse("a7d29707-5201-48f8-a192-818b446f9cb6"),"Adel","Vahdati"),
            new Customer(Guid.Parse("faa7c2dd-a447-4287-8757-13c2cf7ca88a"),"Fereshte","Rahmati")
        };

        foreach(var customer in customers){
            await _customerRepository.CreateAsync(customer);
        }        
    }

    public async Task SeedProductsAsync()
    {
        var products = new List<Product>()
        {
            new Product(Guid.Parse("0eb69dcf-d310-4a37-8bcc-86292f0eafb4"),"Samsug S24 Ultra",Price.Create(1000)),
            new Product(Guid.Parse("1543fe00-5681-4c25-830b-3a5aaf1d9d9a"),"Laptop Lenevo", Price.Create(700))            
        };
        
        foreach(var product in products){
            await _productRepository.CreateAsync(product);
        }
        
    }
}
