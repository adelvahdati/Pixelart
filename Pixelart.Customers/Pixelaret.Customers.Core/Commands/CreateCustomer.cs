using Pixelaret.Customers.Core.Interfaces;

namespace Pixelart.Customers.Core.Commands;

public class CreateCustomer : ICommand{
    public string Name {get;set;}
    public string Family {get;set;}
    public string Address {get;set;}
    public string ZipCode {get;set;}
    public string Phone {get;set;} // TODO: convert it to value object to check the format
    public DateTime BirthDate {get;set;}

}
