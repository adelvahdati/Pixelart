using Pixelart.Orders.Core.Interfaces;
namespace Pixelart.Orders.Core.Entities;
public class AggregateRoot 
{
    private List<IEvent> _events = new();
    public List<IEvent> DomainEvents => _events;

    public void AddEvent(IEvent @event){
        _events.Add(@event);
    }
    public void Clear(){
        _events.Clear();
    }
}