using System.Text;

namespace console_hero.Rendering;

public class ConsoleRenderer: IRenderer
{
    private readonly Map _map;
    private readonly Player _player;
    private readonly InventoryMenu _inventoryMenu;
    private readonly GameState _gameState;

    private readonly PlayerStatusRenderer _playerStatusRenderer;
    private readonly MapRenderer _mapRenderer;
    private readonly InventoryRenderer _inventoryRenderer;
    private readonly PromptRenderer _promptRenderer;
    private readonly LevelInstructionsRenderer _levelInstructionRenderer;
    private readonly CombatRenderer _combatRenderer;
    
    private readonly ScreenBuffer _screenBuffer;
    private readonly string[] _currentFrame;
    private readonly int _totalScreenHeight;

    public ConsoleRenderer(GameState gameState)
    {
        _gameState = gameState;
        _map = gameState.Level.Map;
        _player = gameState.Player;
        _inventoryMenu = gameState.InventoryMenu;
        _playerStatusRenderer = new PlayerStatusRenderer(gameState.Player);
        _mapRenderer = new MapRenderer(gameState.Level.Map,  gameState.Player);
        _inventoryRenderer = new InventoryRenderer(gameState.Player, gameState.InventoryMenu);
        _promptRenderer = new PromptRenderer(gameState.Player, gameState.Level.Map, gameState);
        _levelInstructionRenderer = new LevelInstructionsRenderer(gameState.Level, gameState.KeyBindings);
        _combatRenderer = new CombatRenderer(gameState);
        
        _totalScreenHeight = _map.Height + _inventoryRenderer.Height + _levelInstructionRenderer.Height + 10;
        _screenBuffer = new ScreenBuffer(_totalScreenHeight);
        _currentFrame = new string[_totalScreenHeight];
    }

    private void RenderExploration()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);

        _playerStatusRenderer.Render();
        _inventoryRenderer.Render();
        _mapRenderer.Render();
        _promptRenderer.Render();
        _levelInstructionRenderer.Render();

        int currentLineIndex = 0;
        for (int y = 0; y < _map.Height; y++)
        {
            _currentFrame[currentLineIndex] = _mapRenderer.GetLine(y) + _playerStatusRenderer.GetLine(y);
            currentLineIndex++;
        }
        
        for (int y = 0; y < _inventoryRenderer.Height; y++)
        {
            string leftColumn = _promptRenderer.GetLine(y).PadRightVisible(_map.Width + 4);
            string rightColumn = _inventoryRenderer.GetLine(y);
            
            _currentFrame[currentLineIndex] = leftColumn + rightColumn;
            currentLineIndex++;
        }
        
        for (int y = 0; y < _levelInstructionRenderer.Height; y++)
        {
            _currentFrame[currentLineIndex] = _levelInstructionRenderer.GetLine(y);
            currentLineIndex++;
        }
        _screenBuffer.Draw(_currentFrame);
    }

    private void RenderCombat()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);

        _playerStatusRenderer.Render();
        _inventoryRenderer.Render();
        _mapRenderer.Render();
        _promptRenderer.Render();
        _levelInstructionRenderer.Render();
        _combatRenderer.Render();

        int currentLineIndex = 0;
        for (int y = 0; y < _map.Height; y++)
        {
            _currentFrame[currentLineIndex] = _mapRenderer.GetLine(y) + _playerStatusRenderer.GetLine(y);
            currentLineIndex++;
        }
        
        for (int y = 0; y < _inventoryRenderer.Height + 2; y++)
        {
            string leftColumn = _promptRenderer.GetLine(y).PadRightVisible(_map.Width + 4);
            string rightColumn = _inventoryRenderer.GetLine(y);
            
            _currentFrame[currentLineIndex] = leftColumn + rightColumn;
            currentLineIndex++;
        }
        
        for (int y = 0; y < _levelInstructionRenderer.Height; y++)
        {
            string leftColumn = _combatRenderer.GetLine(y).PadRightVisible(_map.Width + 4);
            string rightColumn = _levelInstructionRenderer.GetLine(y);
            _currentFrame[currentLineIndex] = leftColumn + rightColumn;
            currentLineIndex++;
        }
        _screenBuffer.Draw(_currentFrame);
    }

    private void RenderGamveOver()
    {
        _currentFrame[0] = ("Game Over");
        _screenBuffer.Draw(_currentFrame);
    }
    public void Render()
    {
        if (_gameState.Status == GameStatus.Exploration)
        {
            RenderExploration();
        }
        if (_gameState.Status == GameStatus.Combat)
        {
            RenderCombat();
        }

        if (_gameState.Status == GameStatus.GameOver)
        {
            RenderGamveOver();
        }
    }
}