using Pixelart.Orders.Core.Entities;

namespace Pixelart.Orders.Infrastructure.Data;
public class CustomerEntity{
    public CustomerEntity(Guid id, string name, string family)
    {
        Id = id;
        Name = name;
        Family = family;
    }

    public Guid Id {get;set;}
    public string Name {get;set;}
    public string Family {get;set;}

    public static CustomerEntity CreateFrom(Customer customer){
        return new CustomerEntity(customer.Id,customer.Name,customer.Family);
    }

    public Customer ToCustomer(){
        return new Customer(Id,Name,Family);
    }
}