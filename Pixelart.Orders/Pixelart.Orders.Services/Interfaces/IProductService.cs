using Pixelart.Orders.Core.Entities;

namespace Pixelart.Orders.Services.Intefaces;
public interface IProductService{
    Task<Product?> GetProductAsync(Guid productId);
    Task CreateProductAsync(Product product);
    Task<List<Product>> ListProductsAsync();
}