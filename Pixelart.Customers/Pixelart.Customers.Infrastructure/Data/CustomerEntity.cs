using Pixelart.Customers.Core.Entities;
using Pixelart.Customers.Core.Valueobjects;

namespace Pixelart.Customers.Infrastructure.Data;

public class CustomerEntity
{
    public Guid Id {get;set;}
    public string Name {get; set;}
    public string Family {get; set;}
    public string Address {get; set;}
    public string ZipCode {get; set;}
    public string Phone {get; set;}
    public DateTime BirthDate {get; set;}

    internal static CustomerEntity Create(Customer customer)
    {
        var customerEntity = new CustomerEntity(){
            Id = customer.Id,
            Name = customer.Name.Value,
            Family = customer.Family.Value,
            Address = customer.Address,
            ZipCode = customer.ZipCode,
            Phone = customer.Phone,
            BirthDate = customer.BirthDate
        };
        return customerEntity;   
    }

    internal Customer ToCustomer()
    {
        return Customer.Load(
            Id,
            new Name(){Value = Name},
            Core.Valueobjects.Family.Create(Family),
            Address,
            ZipCode,
            Phone,
            BirthDate
        );
    }
}