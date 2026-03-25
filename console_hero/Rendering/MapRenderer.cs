using System.Text;

namespace console_hero;

public class MapRenderer : IModuleRenderer
{
    private Map _map;
    private Player _player;
    
    private List<string> _mapLines = new List<string>();
    
    public int Height { get; set; }
    public MapRenderer(Map map,  Player player)
    {
        Height = map.Height;
        _map = map;
        _player = player;
    }

    public void Render()
    {
        _mapLines.Clear();
        StringBuilder line = new StringBuilder();
        for (int y = 0; y < _map.Height; y++)
        {
            line.Clear();
            for (int x = 0; x < _map.Width; x++)
            {
                if (_player.Position == (x, y))
                {
                    line.Append(MapSymbols.Player);
                }
                else if (_map.Cells[x, y].IsWall)
                {
                    Console.BackgroundColor = ConsoleColor.White; // Kolor ściany
                    line.Append(MapSymbols.Wall);
                    Console.ResetColor();
                }
                else if (_map.Cells[x, y].Items.Count != 0)
                {
                    line.Append(_map.Cells[x, y].Items.Peek().Symbol);
                }
                else
                {
                    line.Append(MapSymbols.Empty);
                }
            }
            _mapLines.Add(line.ToString());
        }
    }

    public string GetLine(int y)
    {
        if (y < _mapLines.Count)
        {
            return "    " + _mapLines[y]; 
        }
        
        return ""; 
    }
}