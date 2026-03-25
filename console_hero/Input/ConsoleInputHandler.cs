namespace console_hero;

public class ConsoleInputHandler(GameState gameState) : IInputHandler
{
    Player _player = gameState.Player;
    Map _map =  gameState.Level.Map;
    InventoryMenu _inventoryMenu = gameState.InventoryMenu;
    private List<string> _prompts = gameState.Prompts;
    
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
            ConsoleKey.E => new PickupItemCommand(_player, _map),
            ConsoleKey.F => new EquipItemCommand(_player, _map, _inventoryMenu), 
            ConsoleKey.Q => new DropItemCommand(_player, _map, _inventoryMenu),
            
            ConsoleKey.UpArrow => new MoveSelectorInventoryMenuCommand(_inventoryMenu, true),
            ConsoleKey.DownArrow => new MoveSelectorInventoryMenuCommand(_inventoryMenu, false),
            
        
            _ => new DefaultActionCommand(gameState),
        
        };
        command.Execute();
        //
        // _gameState.Player.Move(1, 0);
    }
}