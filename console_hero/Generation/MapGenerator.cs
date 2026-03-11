using console_hero.Models.Items;

namespace console_hero;

public class PredefinedMapGenerator : IMapGenerator
{
    
    public Map GenerateMap()
    {
        string[] layout = 
        {
            "  ██████████████████████████████████████",
            "█*******  222222   6789                █",
            "█cc      sss       6789                █",
            "█cc    123451234512345                 █",
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
                var s =  layout[y][x];
                switch (s)
                {
                    case '█': 
                        map.Cells[x, y].IsWall = true;
                        break;
                    case '*':
                        map.Cells[x, y].Items.Push(new KnightsSword('k', $"{Ansi.FgBlue}Knight's Sword {x}{Ansi.Reset}", 10));
                        break;
                    case '1':
                        map.Cells[x, y].Items.Push(new Bones('b', "Bones"));
                        break;
                    case '3':
                        map.Cells[x, y].Items.Push(new DeadRat('r', "Dead rat"));
                        break;
                    case '4':
                        map.Cells[x, y].Items.Push(new Sand('s', "Sand"));
                        break;
                    case '2':
                        map.Cells[x, y].Items.Push(new GreatSword('G', $"{Ansi.FgRed}The Great Sword {x}{Ansi.Reset}", 10));
                        break;
                    case '5':
                        map.Cells[x, y].Items.Push(new JesusFigner('J', $"{Ansi.FgYellow}JesusFinger {x}{Ansi.Reset}", 100));
                        break;
                    case '6':
                        map.Cells[x, y].Items.Push(new Wand('W', $"{Ansi.FgCyan}Wand {x}{Ansi.Reset}", 5, 10));
                        break;
                    case '7':
                        map.Cells[x, y].Items.Push(new GrandStaff('F', $"{Ansi.FgBrightMagenta}The Grand Staff {x}{Ansi.Reset}", 5, 10));
                        break;
                    case '8':
                        map.Cells[x, y].Items.Push(new Grimoire('R', $"{Ansi.FgMagenta}The Grimoire {x}{Ansi.Reset}",  10));
                        break;
                    case 's':
                        map.Cells[x, y].Items.Push(new TargeShield('h', $"{Ansi.FgGreen}Targe Shield {x}{Ansi.Reset}"));
                        break;
                    case 'c':
                        map.Cells[x, y].Items.Push(new Coins(67));
                        break;
                    case 'g':
                        map.Cells[x, y].Items.Push(new Gold(6767));
                        break;
                }
            }
        }
        return map;
    }
}