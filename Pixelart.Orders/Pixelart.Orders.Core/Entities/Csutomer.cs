using Pixelart.Orders.Core.ValueObjects;

namespace Pixelart.Orders.Core.Entities;

public class Customer
{
    public Customer(Guid id, string name)
    {
        Id = id;
        Name = name;
        

    }

    public Guid Id { get; private set; }
    public string Name {get; private set;}
}