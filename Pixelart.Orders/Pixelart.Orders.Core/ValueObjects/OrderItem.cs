namespace Pixelart.Orders.Core.ValueObjects;
public class OrderItem
{
    public OrderItem(Guid id, string name, Price unitPrice, Quantity quantity)
    {
        Id = id;
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public Guid Id { get; private set; }
    public string Name {get; private set;}
    public Price UnitPrice {get;private set;} 
    public Quantity Quantity {get;private set;}

    internal long GetTotalPrice()
    {
        return UnitPrice.Value * Quantity.Value;
    }
}