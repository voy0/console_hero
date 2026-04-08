namespace console_hero;

public interface IMenu
{
    public int CurrentIndex { get; }
    public bool InFocus {get; set;}
    bool IsEnabled { get; set; }
    public void GoUp();
    public void GoDown();
    public void ValidateIndex();

}