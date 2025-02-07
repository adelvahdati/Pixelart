using Pixelaret.Customers.Core.Interfaces;

namespace Pixelart.Customers.Core.Commands;

public class DeleteCustomer : ICommand{
    public Guid CustomerId {get;set;}
}
