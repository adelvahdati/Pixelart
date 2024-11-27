using ICommand = Pixelart.Orders.Interfaces.ICommand;
namespace Pixelart.Orders.Commands;
public class CancelOrder : ICommand
{
    public Guid OrderId {get;set;}
}