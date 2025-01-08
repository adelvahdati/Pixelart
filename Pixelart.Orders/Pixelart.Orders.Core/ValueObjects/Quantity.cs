namespace Pixelart.Orders.Core.ValueObjects;

public class Quantity{
    private Quantity(long value)
    {
        Value = value;
    }

    public static Quantity Create(long value){
        if(value<=0)
            throw new Exception("Quantity must be greater than zero ");
        
        return new Quantity(value);
        

    }
    public long Value {get; private set;}

}