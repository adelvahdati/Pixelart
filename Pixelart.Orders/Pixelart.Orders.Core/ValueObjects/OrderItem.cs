namespace Pixelart.Orders.Core.ValueObjects;
public class OrderItem
{
    public OrderItem(Guid productId, string name, Price unitPrice, Quantity quantity)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }
    public OrderItem(Guid id, Guid productId, string name, Price unitPrice, Quantity quantity)
    {
        Id = id;
        ProductId = productId;
        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public Guid Id { get; private set; }
    public Guid ProductId {get; private set;}
    public string Name {get; private set;}
    public Price UnitPrice {get;private set;} 
    public Quantity Quantity {get;private set;}

    internal long GetTotalPrice()
    {
        return UnitPrice.Value * Quantity.Value;
    }
}