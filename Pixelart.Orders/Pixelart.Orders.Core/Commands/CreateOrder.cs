using Pixelart.Orders.Core.Entities;
using ICommand = Pixelart.Orders.Interfaces.ICommand;

namespace Pixelart.Orders.Commands;
public class CreateOrder : ICommand
{
    public Guid CustomerId {get; set;}
    public List<Product> Products {get;set;}
}
