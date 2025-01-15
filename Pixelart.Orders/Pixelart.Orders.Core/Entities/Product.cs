using System.Runtime.InteropServices;
using Pixelart.Orders.Core.ValueObjects;

namespace Pixelart.Orders.Core.Entities;
public class Product
{
    public Product(Guid id, string name, Price unitPrice)
    {
        Id = id;
        Name = name;
        UnitPrice = unitPrice;        
    }

    public Guid Id { get; private set; }
    public string Name {get; private set;}
    public Price UnitPrice {get;private set;} 
}
