using Pixelart.Orders.Core.Entities;

namespace Pixelart.Orders.Services.Repositories;

public interface IProductRepository{
    Task<Product?> GetAsync(Guid productId);
    Task CreateAsync(Product product);
    Task<List<Product>> ListAsync();
}