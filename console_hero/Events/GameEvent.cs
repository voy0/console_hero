namespace console_hero.Events;

public enum EventType
{
    EnemyDied,
    Noise
}
public class GameEvent
{
    public EventType Type { get; set; }
    public Guild Guild { get; set; }
    public (int x, int y) Position { get; set; }
    public int Intensity{get;set;}
    public Map? Map { get; set; }

    public GameEvent(EventType eventType, Guild guild)
    {
        Type = eventType;
        Guild = guild;
    }
    public GameEvent(EventType eventType, Map map, (int x, int y) position, int intensity)
    {
        Type = eventType;
        Map = map;
        Position = position;
        Intensity = intensity;
    }
}