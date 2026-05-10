namespace console_hero;

public class CoreAttribute : IAttribute
{
    private int _baseValue;
    public int Value { get => _baseValue; set  => _baseValue = value; }
    public CoreAttribute(int value)
    {
        _baseValue = value;
    }
}