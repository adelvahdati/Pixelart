using Pixelart.Customers.Core.Entities;

namespace Pixelaret.Customers.Applications.Dtos;
public class CustomerDto
{
    public CustomerDto(Guid id, string name, string family, string address, string zipCode, string phone, DateTime birthDate)
    {
        Id = id;
        Name = name;
        Family = family;
        Address = address;
        ZipCode = zipCode;
        Phone = phone;
        BirthDate = birthDate;
    }

    public Guid Id {get;set;}
    public string Name {get; set;}
    public string Family {get; set;}
    public string Address {get; set;}
    public string ZipCode {get; set;}
    public string Phone {get;set;} 
    public DateTime BirthDate {get; set;}

    public static CustomerDto CreateFrom(Customer customer){
        return new CustomerDto(
            customer.Id,
            customer.Name.Value,
            customer.Family.Value,
            customer.Address,
            customer.ZipCode,
            customer.Phone,
            customer.BirthDate);
    }    
}