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
        GameConfig config = ConfigLoader.LoadConfig();


        ILoggerStrategy loggerStrategy = new CompositeLogger(
            new MemoryLogger(), 
            new FileLogger(config.PlayerName, config.LogDirectory)
        );
        GameLogger.Instance.SetStrategy(loggerStrategy);

        GameLogger.Instance.Log($"Game started, player name: {config.PlayerName}");
        
        _gameState.Run();
        _gameRenderer.Render();
        
        while (_gameState.IsRunning)
        {
            _inputHandler.HandleInput();
            _gameRenderer.Render();
        }
    }
}