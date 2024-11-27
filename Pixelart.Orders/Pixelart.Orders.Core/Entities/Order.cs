namespace Pixelart.Orders.Core.Entities;
public class Order
{
    private long _totalPrice =0;
    private List<Product> _details =new();

    public Guid Id {get;private set;}
    public List<Product> Details => _details;
    public Customer Customer {get;set;}

    public long TotalPrice => _totalPrice;

    public void AddProduct(Product product)
    {
        _details.Add(product);
        _totalPrice = _totalPrice + product.GetPrice();
    }
    public void RemoveProduct(Guid productId)
    {
        var product = _details.FirstOrDefault(product => product.Id == productId);
        if(product!=null)
        {
            _details.Remove(product);
            _totalPrice = _totalPrice - product.GetPrice();
        }
    }   
}

