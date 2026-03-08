namespace console_hero;

public class PredefinedMapGenerator : IMapGenerator
{
    
    public Map GenerateMap()
    {
        string[] layout = 
        {
            "  ██████████████████████████████████████",
            "█                                      █",
            "█  █████████████████████████████████   █",
            "█  █                               █   █",
            "█  █   █████████████   █████████   █   █",
            "█  █   █           █   █       █   █   █",
            "█  █   █   █████   █   █   █   █   █   █",
            "█  █   █   █       █   █   █   █   █   █",
            "█  █   █   █████████   █████   █   █   █",
            "█  █   █                       █   █   █",
            "█  █   █████████████████████████   █   █",
            "█  █                               █   █",
            "█  █████████       █     ███████████   █",
            "█                  █                   █",
            "█   █████████      █      ██████████   █",
            "█   █                              █   █",
            "█   █   ████   █████████   █████   █   █",
            "█   █                              █   █",
            "█   ████████████████████████████████   █",
            "████████████████████████████████████████"
        };
        int width = 40;
        int height = 20;
        Map map = new Map(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (layout[y][x] == '█')
                {
                    map.Cells[x, y].IsWall = true;
                }
            }
        }
        return map;
    }
}