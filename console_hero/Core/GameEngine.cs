namespace console_hero;
using System.Diagnostics;
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
        
        
        Stopwatch enemyTimer = new Stopwatch();
        enemyTimer.Start();
        int enemyMoveIntervalMs = 500;
        
        while (_gameState.IsRunning)
        {
            bool needsRedraw = false;
            if (Console.KeyAvailable)
            {
                _inputHandler.HandleInput();
                needsRedraw = true;
            }

            if (enemyTimer.ElapsedMilliseconds >= enemyMoveIntervalMs)
            {
                _gameState.EnemyMovementManager.MoveAllRandomly();
                enemyTimer.Restart();
                needsRedraw = true;
            }
            if (needsRedraw)
            { 
                _gameRenderer.Render();
            }
            Thread.Sleep(16);
        }
    }
}