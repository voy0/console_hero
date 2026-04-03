namespace console_hero;

public class Level
{
    public Map Map { get; set; }
    public List<KeyActions> KeyActionsList { get; set; }

    public Level(Map map, List<KeyActions> keyActionsList)
    {
        Map = map;
        KeyActionsList = keyActionsList;
    }
}