using System.Text;

namespace console_hero;

public class ConsoleRenderer(GameState gameState) : IRenderer
{
    private readonly Map _map = gameState.Map;
    private readonly Player _player = gameState.Player;
    private readonly InventoryMenu _inventoryMenu = gameState.InventoryMenu;
    
    private readonly PlayerStatusRenderer _playerStatusRenderer = new PlayerStatusRenderer(gameState.Player);
    private readonly MapRenderer _mapRenderer = new MapRenderer(gameState.Map,  gameState.Player);
    private readonly InventoryRenderer _inventoryRenderer = new InventoryRenderer(gameState.Player, gameState.InventoryMenu);
    private readonly PickupPromptRenderer _pickupPromptRenderer = new PickupPromptRenderer(gameState.Player, gameState.Map);
    
    private readonly StringBuilder _frame  = new StringBuilder();
    
    public void Render()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
        Console.Clear();
        
        _frame.Clear();
        _playerStatusRenderer.Render();
        _inventoryRenderer.Render();
        _mapRenderer.Render();
        _pickupPromptRenderer.Render();

        for (int y = 0; y < _map.Height; y++)
        {
            _frame.AppendLine(_mapRenderer.GetLine(y) + _playerStatusRenderer.GetLine(y));
        }
        
        for (int y = 0; y < _inventoryRenderer.Height; y++)
        {
            string leftColumn = _pickupPromptRenderer.GetLine(y).PadRightVisible(gameState.Map.Width);
            string rightColumn = _inventoryRenderer.GetLine(y);
    
            _frame.AppendLine(leftColumn + rightColumn);
        }
        
        Console.Write(_frame);
    }
}