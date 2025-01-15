namespace Pixelart.Orders.Infrastructure.Services;

public interface IDataSeeder
{
    Task SeedCustomersAsync();
    Task SeedProductsAsync();
}
