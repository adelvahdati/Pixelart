using Pixelart.Orders.Core.Enums;
using Pixelart.Orders.Core.Events;
using Pixelart.Orders.Core.ValueObjects;

namespace Pixelart.Orders.Core.Entities;
public class Order: AggregateRoot
{
    
    private long _totalPrice =0;
    private List<OrderItem> _details =new();

    public Guid Id {get;private set;}
    public List<OrderItem> Details => _details;
    public Customer Customer {get;private set;}
    public OrderState State {get;  private set;}
    public long TotalPrice => _totalPrice;

    
    public Order(Guid id, List<OrderItem> orderItems, Customer customer, OrderState state, long totalPrice ){
        Id = id;
        _details = orderItems;
        State = state;
        _totalPrice = totalPrice;
    }

    public Order(Customer customer){
        Id = Guid.NewGuid();
        Customer =customer;
    }
    
    // public Order(Customer customer, List<OrderItem> items){
    //     Id = Guid.NewGuid();
    //     Customer =customer;
    //     _details = items;
    // }
    

    public void AddOrderItem(OrderItem orderItem)
    {
        //TODO : Check duplication insertion
        _details.Add(orderItem);
        _totalPrice = _totalPrice + orderItem.GetTotalPrice();
    }
    public void RemoveOrderItem(Guid productId)
    {
        var product = _details.FirstOrDefault(product => product.Id == productId);
        if(product!=null)
        {
            _details.Remove(product);
            _totalPrice = _totalPrice - product.GetTotalPrice();
        }
    }
    public void Cancel()
    {
        if(State == OrderState.Deliverd)
            throw new Exception("The order can not be canceled");
        
        if(State == OrderState.Cancel)
            return;
        
        if(State == OrderState.Payed)
            State =OrderState.Refund;
        
        if(State == OrderState.Created)
            State = OrderState.Cancel;

        var evn = new OrderCanceled(Id,Customer.Id);
        AddEvent(evn);
    }   
}

