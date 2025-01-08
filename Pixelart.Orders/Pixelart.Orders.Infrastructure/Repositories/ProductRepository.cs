using Microsoft.EntityFrameworkCore;
using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Infrastructure.Data;
using Pixelart.Orders.Services.Repositories;

namespace Pixelart.Orders.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Product product)
    {
        await _dbContext.Products.AddAsync(ProductEntity.CreateFrom(product));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Product?> GetAsync(Guid productId)
    {
        var productEntity = await _dbContext.Products.FindAsync(productId);
        if(productEntity == null)
            return null;
        
        return productEntity.ToProduct();
    }

    public async Task<List<Product>> ListAsync()
    {
        var producEntities =  await _dbContext.Products.ToListAsync();
        return producEntities.Select(productEntity => productEntity.ToProduct()).ToList();
    }
}
