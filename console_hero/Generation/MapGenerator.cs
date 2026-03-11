using console_hero.Models.Items;

namespace console_hero;

public class PredefinedMapGenerator : IMapGenerator
{
    
    public Map GenerateMap()
    {
        string[] layout = 
        {
            "  ██████████████████████████████████████",
            "█*******  222222                       █",
            "█cc      sss                           █",
            "█cc                                    █",
            "█gg    █████████████   █████████       █",
            "█gg    █           █   █       █       █",
            "█      █   █████   █   █   █   █       █",
            "█      █   █  *    █   █   █   █       █",
            "█      █   █████████   █████   █       █",
            "█      █                       █       █",
            "█      █████████████████████████       █",
            "█                                      █",
            "█                  █                   █",
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

                if (layout[y][x] == '*')
                {
                    map.Cells[x, y].Items.Push(new KnightsSword('S', $"{Ansi.FgBlue}Knight's Sword {x}{Ansi.Reset}", 10));
                }

                if (layout[y][x] == '2')
                {
                    map.Cells[x, y].Items.Push(new GreatSword('2', $"{Ansi.FgRed}The Great Sword {x}{Ansi.Reset}", 10));
                }

                if (layout[y][x] == 's')
                {
                    map.Cells[x, y].Items.Push(new TargeShield('s', $"{Ansi.FgGreen}Targe Shield {x}{Ansi.Reset}"));
                }
                if (layout[y][x] == 'c')
                {
                    map.Cells[x, y].Items.Push(new Coins(67));
                }

                if (layout[y][x] == 'g')
                {
                    map.Cells[x, y].Items.Push(new Gold(6767));
                }
            }
        }
        return map;
    }
}