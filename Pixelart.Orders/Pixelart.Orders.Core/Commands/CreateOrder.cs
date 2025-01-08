using Pixelart.Orders.Core.Entities;
using Pixelart.Orders.Core.ValueObjects;
using ICommand = Pixelart.Orders.Interfaces.ICommand;

namespace Pixelart.Orders.Commands;
public class CreateOrder : ICommand
{
    public Guid CustomerId {get; set;}
    public Basket Basket {get;set;}
}
