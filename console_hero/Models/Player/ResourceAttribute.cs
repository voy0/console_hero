namespace console_hero;

public class ResourceAttribute : IResourceAttribute
{
    private int _value;

    public int Value
    {
        get => _value;
        private set { _value = Math.Clamp(value, MinValue, MaxValue); }
    }

    public bool IsEmpty => Value == MinValue;
    public int MinValue { get; }
    public int MaxValue { get; }

    public void Increase(int dValue)
    {
        if (dValue < 0) 
            throw new ArgumentOutOfRangeException(nameof(dValue), "Increase must be greater than or equal to zero!");;
        Value += dValue;
    }
    public void Decrease(int dValue)
    {
        if (dValue < 0) 
            throw new ArgumentOutOfRangeException(nameof(dValue), "Decrease must be greater than or equal to zero!");
        Value -= dValue;
    }

    public ResourceAttribute(int value, int minValue = 0, int maxValue = 100)
    {
        MinValue = minValue;
        MaxValue = maxValue;
        Value = value;
    }
}