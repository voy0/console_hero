namespace console_hero;

public interface IHandler 
{
    void SetNext(IHandler handler);
    void Handle();
}