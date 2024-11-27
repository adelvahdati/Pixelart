using System.Runtime.InteropServices;

namespace Pixelart.Orders.Core.Entities;
public class Product
{
    public Guid Id { get; set; }
    public string Name {get;set;}
    public Price UnitPrice {get;set;} 
    public int Quantity {get;set;}

    public long GetPrice(){
        
        return UnitPrice.Value*Quantity;
    }    
}
