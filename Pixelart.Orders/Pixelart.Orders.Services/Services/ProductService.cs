using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Services.Intefaces;
using Pixelart.Orders.Services.Repositories;

namespace Pixelart.Orders.Services.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateProductAsync(Product product)
    {
        await _repository.CreateAsync(product);
    }

    public async Task<Product?> GetProductAsync(Guid productId)
    {
        return await _repository.GetAsync(productId);
    }

    public async Task<List<Product>> ListProductsAsync()
    {
        return await _repository.ListAsync();
    }
}
