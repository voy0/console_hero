namespace console_hero;

public class GameEngine
{
    private GameState _gameState;
    private IRenderer _gameRenderer;
    private IInputHandler _inputHandler;

    public GameEngine(GameState gameState, IRenderer gameRenderer, IInputHandler inputHandler)
    {
        
        _gameState = gameState;
        _gameRenderer = gameRenderer;
        _inputHandler = inputHandler;
    }
    public void Run()
    {
        _gameState.Run();
        _gameRenderer.Render();
        
        while (_gameState.IsRunning)
        {
            _inputHandler.HandleInput();
            _gameRenderer.Render();
        }
    }
}