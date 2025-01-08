namespace Pixelart.Orders.Core.ValueObjects;

public class Price
{
    private readonly long _value;
    public long Value => _value;
    private Price(long value)
    {
        _value = value;
    }

    public static Price Create(long value)
    {
        if (value < 0)
            throw new Exception("Price can not be negative");

        return new Price(value);
    }
}