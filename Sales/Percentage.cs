namespace Sales;

public class Percentage
{
    public double Value { get; }

    public Percentage(double value)
    {
        if (value is < 0 or > 100)
            throw new ArgumentException();

        Value = value;
    }

    public Currency Of(Currency price) => new(Value / 100 * price.Value);
}