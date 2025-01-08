using Pixelart.Orders.Core.ValueObjects;

namespace Pixelart.Orders.Core.Entities;

public class Customer
{
    public Customer(Guid id, string name, string family)
    {
        Id = id;
        Name = name;
        Family = family;
    }

    public Guid Id { get; private set; }
    public string Name {get; private set;}
    public string Family {get; private set;}
}