namespace console_hero;

public class ConsoleInputHandler(GameState gameState) : IInputHandler
{
    Player _player = gameState.Player;
    Map _map =  gameState.Level.Map;
    InventoryMenu _inventoryMenu = gameState.InventoryMenu;
    private List<string> _prompts = gameState.Prompts;
    
    public void HandleInput() 
    {
        ConsoleKey key = Console.ReadKey(intercept: true).Key;
        KeyBindings.KeyToAction.TryGetValue(key, out KeyActions action);
        
        ICommand command = action switch
        {
            KeyActions.MoveLeft => new MovePlayerCommand(_player, _map,-1, 0),
            KeyActions.MoveRight => new MovePlayerCommand(_player, _map, 1, 0),
            KeyActions.MoveUp => new MovePlayerCommand(_player, _map, 0, -1),
            KeyActions.MoveDown => new MovePlayerCommand(_player, _map, 0, 1),
            KeyActions.PickupItem => new PickupItemCommand(_player, _map),
            KeyActions.EquipItem => new EquipItemCommand(_player, _map, _inventoryMenu), 
            KeyActions.DropItem => new DropItemCommand(_player, _map, _inventoryMenu),
            
            KeyActions.SelectInventoryUp => new MoveSelectorInventoryMenuCommand(_inventoryMenu, true),
            KeyActions.SelectInventoryDown => new MoveSelectorInventoryMenuCommand(_inventoryMenu, false),
            
        
            _ => new DefaultActionCommand(gameState),
        
        };
        command.Execute();
    }
}