namespace console_hero;

public interface IResourceAttribute : IAttribute
{
    int MaxValue { get; }
    bool IsEmpty { get; }
    void Increase(int dValue); 
    void Decrease(int dValue); 
    
}