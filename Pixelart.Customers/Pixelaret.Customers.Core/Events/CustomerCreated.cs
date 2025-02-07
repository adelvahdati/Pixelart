using Pixelart.Customers.Core.Intefaces;

namespace Pixelart.Customers.Core.Events;

public class CustomerCreated : IEvent
{
    public CustomerCreated(Guid customerId, string name, string family)
    {
        CustomerId = customerId;
        Name = name;
        Family = family;
    }

    public Guid CustomerId {get;set;}
    public string Name {get;set;}
    public string Family {get;set;}
}