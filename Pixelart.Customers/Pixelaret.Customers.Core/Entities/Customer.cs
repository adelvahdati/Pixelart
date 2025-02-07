using Pixelart.Customers.Core.Events;
using Pixelart.Customers.Core.Valueobjects;

namespace Pixelart.Customers.Core.Entities;

public class Customer : Aggregate
{

    public Name Name {get;private set;}
    public Family Family {get;private set;}
    public string Address {get;private set;}
    public string ZipCode {get;private set;}
    public string Phone {get;private set;} // TODO: convert it to value object to check the format
    public DateTime BirthDate {get;private set;}

    private Customer(Guid id, Name name, Family family, string address, string zipCode, string phone,DateTime birthDate)
    {
        Id = id;
        Name = name;
        Family = family;
        Address = address;
        ZipCode = zipCode;
        Phone = phone;
        BirthDate = birthDate;
    }
    private Customer(Name name, Family family, string address, string zipCode, string phone,DateTime birthDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        Family = family;
        Address = address;
        ZipCode = zipCode;
        Phone = phone;
        BirthDate = birthDate;
    }

    public static Customer Create(Name name, Family family, string address, string zipCode, string phone,DateTime birthDate)
    {
        var customer = new Customer(name,family,address,zipCode,phone,birthDate);
        customer.AddEvent(new CustomerCreated(customer.Id,name.Value,family.Value));
        return customer;
    }
    public static Customer Load(Guid id, Name name, Family family, string address, string zipCode, string phone,DateTime birthDate)
    {
        return new Customer(id,name,family,address,zipCode,phone,birthDate);
    }
    public void Update(string name, string family,string address,string zipCode,string phone,DateTime birthDate)
    {
        Name = new Name(){Value = name};
        Family = Family.Create(family);
        Address = address;
        ZipCode = zipCode;
        BirthDate = birthDate;
        Phone = phone;
        AddEvent(new CustomerUpdated(Id,name,family));
    }    
}