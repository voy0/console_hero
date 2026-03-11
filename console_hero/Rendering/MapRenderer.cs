using System.Text;

namespace console_hero;

public class MapRenderer : IRenderable
{
    private Map _map;
    private Player _player;
    
    private List<string> _mapLines = new List<string>();
    
    public int Height => _map.Height;
    public MapRenderer(Map map,  Player player)
    {
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
                    line.Append(MapSymbols.Wall);
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