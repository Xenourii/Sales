namespace Sales;

public class Currency : IComparable
{
    public double Value { get; }

    public Currency()
    {
        Value = 0;
    }

    public Currency(double value)
    {
        if (value < 0)
            throw new ArgumentException("Currency cannot be negative");

        Value = value;
    }

    public override string ToString() => $"${Value}";

    public static Currency operator +(Currency a, Currency b)
    {
        return new Currency(a.Value + b.Value);
    }

    public static Currency operator -(Currency a, Currency b)
    {
        return new Currency(a.Value - b.Value);
    }

    public int CompareTo(object? obj)
    {
        var currency = obj as Currency;
        return Value.CompareTo(currency?.Value);
    }
}