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
    public int BaseMaxValue { get; }
    public int MaxValue { get; private set; }
    public void Scale(double multiplier)
    {
        if (MaxValue == 0) return; 

        double healthPercentage = (double)Value / MaxValue;

        MaxValue = Math.Max(1, (int)(BaseMaxValue * multiplier));

        _value = Math.Clamp((int)(MaxValue * healthPercentage), MinValue, MaxValue);
    }
    public void Increase(int dValue)
    {
        if (dValue < 0) 
            throw new ArgumentOutOfRangeException(nameof(dValue), "Increase must be greater than or equal to zero!");;
        Value = Math.Min(Value + dValue, MaxValue);
    }
    public void Decrease(int dValue)
    {
        if (dValue < 0) 
            throw new ArgumentOutOfRangeException(nameof(dValue), "Decrease must be greater than or equal to zero!");
        Value = Math.Max(Value -  dValue, MinValue);
    }

    public ResourceAttribute(int value, int? maxValue = null, int? minValue = null)
    {
        MinValue = minValue ?? 0;
        BaseMaxValue = maxValue ?? value;
        MaxValue = BaseMaxValue;
        Value = value;
    }
}