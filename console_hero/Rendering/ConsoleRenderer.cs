using System.Text;
using System;

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
    private readonly LogRenderer _logRenderer; 
    
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
        _mapRenderer = new MapRenderer(gameState.Level.Map,  gameState.Player, new MapSymbols());
        _inventoryRenderer = new InventoryRenderer(gameState.Player, gameState.InventoryMenu);
        _promptRenderer = new PromptRenderer(gameState.Player, gameState.Level.Map, gameState);
        _levelInstructionRenderer = new LevelInstructionsRenderer(gameState.Level, gameState.KeyBindings);
        _combatRenderer = new CombatRenderer(gameState);
        _logRenderer = new LogRenderer(); 
        
        int widthCol1 = 50; 
        int widthCol2 = 50; 
        
        _logRenderer.MaxWidth = _map.Width + 4 - widthCol1 - widthCol2;
        
        _totalScreenHeight = _map.Height + _inventoryRenderer.Height + _levelInstructionRenderer.Height + 20;
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
        _logRenderer.Render();

        int currentLineIndex = 0;
        
        for (int y = 0; y < _map.Height; y++)
        {
            _currentFrame[currentLineIndex] = _mapRenderer.GetLine(y) + _playerStatusRenderer.GetLine(y);
            currentLineIndex++;
        }
        
        int bottomSectionHeight = Math.Max(Math.Max(_promptRenderer.Height, _logRenderer.Height), _inventoryRenderer.Height);
        
        for (int y = 0; y < bottomSectionHeight; y++)
        {
            string col1 = _promptRenderer.GetLine(y).PadRightVisible(45);
            
            string col2 = _inventoryRenderer.GetLine(y).PadRightVisible(45);

            string col3 = _logRenderer.GetLine(y);
            
            _currentFrame[currentLineIndex] = col1 + col2 + col3;
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
        _logRenderer.Render();

        int currentLineIndex = 0;
        
        for (int y = 0; y < _map.Height; y++)
        {
            _currentFrame[currentLineIndex] = _mapRenderer.GetLine(y) + _playerStatusRenderer.GetLine(y);
            currentLineIndex++;
        }
        
        int bottomSectionHeight = Math.Max(Math.Max(_promptRenderer.Height, _logRenderer.Height), _inventoryRenderer.Height + 2);
        
        for (int y = 0; y < bottomSectionHeight; y++)
        {
            string col1 = _promptRenderer.GetLine(y).PadRightVisible(40);
            string col2 = _inventoryRenderer.GetLine(y).PadRightVisible(35);
            string col3 = _logRenderer.GetLine(y);
            
            _currentFrame[currentLineIndex] = col1 + col2 + col3;
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
        Console.Clear();
        _currentFrame[0] = "==== G A M E   O V E R ====";
        _currentFrame[3] = GameLogger.Instance.GetFilePath();
    
        _screenBuffer.Draw(_currentFrame);
    }
    
    public void Render()
    {
        if (_gameState.ForceRedraw)
        {
            Console.Clear(); 
            _screenBuffer.ResetBuffer(); 
            _gameState.ForceRedraw = false; 
        }
        
        if (_gameState.Status == GameStatus.Exploration)
        {
            RenderExploration();
        }
        else if (_gameState.Status == GameStatus.Combat)
        {
            RenderCombat();
        }
        else if (_gameState.Status == GameStatus.GameOver)
        {
            RenderGamveOver();
        }
    }
}