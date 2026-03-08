namespace console_hero;

public class ConsoleInputHandler : IInputHandler
{
    GameState _gameState;
    public ConsoleInputHandler(GameState gameState)
    {
        _gameState = gameState;
    }
    // TODO add chain of responsibility to movement handling 
    public void HandleInput() 
    {
        ConsoleKey key = Console.ReadKey(intercept: true).Key;
        ICommand command = key switch
        {
            ConsoleKey.A => new MovePlayerCommand(_gameState, -1, 0),
            ConsoleKey.D => new MovePlayerCommand(_gameState, 1, 0),
            ConsoleKey.W => new MovePlayerCommand(_gameState, 0, -1),
            ConsoleKey.S => new MovePlayerCommand(_gameState, 0, 1),
        
            _ => new DoNothingCommand(),
        
        };
        command.Execute();
        //
        // _gameState.Player.Move(1, 0);
    }
}