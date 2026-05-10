namespace console_hero.Events;

public class GameEventManager
{
    private static GameEventManager? _instance;
    public static GameEventManager Instance => _instance ??= new GameEventManager();


    private readonly Dictionary<EventType, List<IObserver>> _observers = new();

    public void Subscribe(EventType type, IObserver observer)
    {
        if (!_observers.ContainsKey(type)) _observers[type] = new List<IObserver>();
        if (!_observers[type].Contains(observer)) _observers[type].Add(observer);
    }

    public void Notify(GameEvent ev)
    {
        if (!_observers.ContainsKey(ev.Type)) return;

        foreach (var observer in _observers[ev.Type].ToList())
        {
            observer.OnNotify(ev);
        }
    }

    public void Unsubscribe(EventType type, IObserver observer)
    {
        if (_observers.ContainsKey(type)) _observers[type].Remove(observer);
    }
}