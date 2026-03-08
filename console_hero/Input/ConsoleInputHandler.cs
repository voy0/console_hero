namespace console_hero;

public class ConsoleInputHandler : IInputHandler
{
    Player _player;
    Map _map;
    public ConsoleInputHandler(GameState gameState)
    {
        _player = gameState.Player;
        _map = gameState.Map;
    }
    // TODO add chain of responsibility to movement handling 
    public void HandleInput() 
    {
        ConsoleKey key = Console.ReadKey(intercept: true).Key;
        ICommand command = key switch
        {
            ConsoleKey.A => new MovePlayerCommand(_player, _map,-1, 0),
            ConsoleKey.D => new MovePlayerCommand(_player, _map, 1, 0),
            ConsoleKey.W => new MovePlayerCommand(_player, _map, 0, -1),
            ConsoleKey.S => new MovePlayerCommand(_player, _map, 0, 1),
            ConsoleKey.Q => new PickupItemCommand(_player, _map),
            ConsoleKey.E => new EquipItemCommand(_player, _map),
            ConsoleKey.F => new DropItemCommand(_player, _map),
        
            _ => new DoNothingCommand(),
        
        };
        command.Execute();
        //
        // _gameState.Player.Move(1, 0);
    }
}