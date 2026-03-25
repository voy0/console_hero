namespace console_hero;

public class Level
{
    public Map Map { get; set; }
    public List<string> Instructions { get; set; }

    public Level(Map map = null, List<string> instructions = null)
    {
        Map = map ?? new Map();
        Instructions = instructions;
    }
}