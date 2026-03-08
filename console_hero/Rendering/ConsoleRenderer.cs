using System.Text;

namespace console_hero;

public class ConsoleRenderer(GameState gameState) : IRenderer
{
    private readonly Map _map = gameState.Map;
    private readonly Player _player = gameState.Player;
    private readonly PlayerStatusRenderer _playerStatusRenderer = new PlayerStatusRenderer(gameState.Player);
    private readonly StringBuilder _frame  = new StringBuilder();
    
    public void Render()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
        Console.Clear();
        
        _frame.Clear();
        _playerStatusRenderer.Render();
        
        for (int y = 0; y < _map.Height; y++)
        {
            for (int x = 0; x < _map.Width; x++)
            {
                if (_player.Position == (x, y))
                {
                    _frame.Append(MapSymbols.Player);
                }
                else if (_map.Cells[x, y].IsWall)
                {
                    _frame.Append(MapSymbols.Wall);
                }
                else if (_map.Cells[x, y].Items.Count != 0)
                {
                    _frame.Append(_map.Cells[x, y].Items.Peek().Symbol);
                }
                else
                {
                    _frame.Append(MapSymbols.Empty);
                }
            }
            _frame.Append(_playerStatusRenderer.GetLine(y));
            _frame.Append("\n");
        }
        Console.Write(_frame);
    }
}