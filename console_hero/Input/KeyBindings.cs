namespace console_hero;

public enum KeyActions
{
    MoveUp,
    MoveDown,
    MoveLeft,
    MoveRight,
    PickupItem,
    DropItem,
    EquipItem,
    SelectInventoryUp,
    SelectInventoryDown,
}
public class KeyBindings //TODO dodaj do mapowania od razu komende, bo czemu nie
{
    private Player _player;
    private Map _map;
    private InventoryMenu _inventoryMenu;
    public readonly Dictionary<KeyActions, (ConsoleKey Key, ICommand Command, string Description)> Actions;
    public readonly Dictionary<ConsoleKey, KeyActions> KeyToAction;
    public KeyBindings(GameState gameState)
    {
        _player = gameState.Player;
        _map = gameState.Level.Map;
        _inventoryMenu = gameState.InventoryMenu;
        
        Actions = new()
        {
            { KeyActions.MoveUp,     (ConsoleKey.W, new MovePlayerCommand(_player, _map,0, -1), "move up") },
            { KeyActions.MoveDown,   (ConsoleKey.S, new MovePlayerCommand(_player, _map, 0, 1), "move down") },
            { KeyActions.MoveLeft,   (ConsoleKey.A, new MovePlayerCommand(_player, _map, -1, 0), "move left") },
            { KeyActions.MoveRight,  (ConsoleKey.D, new MovePlayerCommand(_player, _map, 1, 0), "move right") },
            { KeyActions.PickupItem, (ConsoleKey.E, new PickupItemCommand(_player, _map), "pick up item") },
            { KeyActions.DropItem,   (ConsoleKey.Q, new DropItemCommand(_player, _map, _inventoryMenu), "drop item") },
            { KeyActions.EquipItem,  (ConsoleKey.F, new EquipItemCommand(_player, _map, _inventoryMenu), "equip item") },
            { KeyActions.SelectInventoryDown, (ConsoleKey.DownArrow, new MoveSelectorInventoryMenuCommand(_inventoryMenu, false), "select inventory down")},
            { KeyActions.SelectInventoryUp, (ConsoleKey.UpArrow, new MoveSelectorInventoryMenuCommand(_inventoryMenu, true), "select inventory up")},
        };
        KeyToAction = Actions.ToDictionary(kvp => kvp.Value.Key, kvp => kvp.Key);
    }
    
    
}