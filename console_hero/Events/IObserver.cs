namespace console_hero.Events;

public interface IObserver
{
    void OnNotify(GameEvent gameEvent);
}