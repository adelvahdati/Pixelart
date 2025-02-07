using Pixelart.Customers.Core.Intefaces;

namespace Pixelart.Customers.Core.Entities;
public class Aggregate 
{
    public Guid Id {get;set;}
    private List<IEvent> _events = new();
    public List<IEvent> DomainEvents => _events;

    public void AddEvent(IEvent @event){
        _events.Add(@event);
    }
    public void Clear(){
        _events.Clear();
    }
}