namespace console_hero;

public class Level
{
    public Map Map { get; set; }
    public KeyBindings KeyBindings { get; set; }
    public List<string> Instructions { get; set; }

    public Level(KeyBindings keyBindings, Map map = null, List<string> instructions = null)
    {
        KeyBindings = keyBindings;
        Map = map ?? new Map();
        Instructions = instructions;
    }
}