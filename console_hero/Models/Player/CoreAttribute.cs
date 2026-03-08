namespace console_hero;

public class CoreAttribute : IAttribute
{
    private int _baseValue;
    public int Value => _baseValue;
    public CoreAttribute(int value)
    {
        _baseValue = value;
    }
}