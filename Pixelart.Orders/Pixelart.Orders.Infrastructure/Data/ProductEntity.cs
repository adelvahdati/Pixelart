using System.Diagnostics;
using Pixelart.Orders.Core.Entities;
using UnitPrice = Pixelart.Orders.Core.ValueObjects.Price;
namespace Pixelart.Orders.Infrastructure.Data;

public class ProductEntity
{
    public ProductEntity(Guid id, string name, long price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public Guid Id {get;set;}
    public string Name {get;set;}
    public long Price {get;set;}

    public static ProductEntity CreateFrom(Product product){
        return new ProductEntity(product.Id,product.Name,product.UnitPrice.Value);
    }

    public Product ToProduct(){
        return new Product(Id,Name,UnitPrice.Create(Price));
    }
}