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
public static class KeyBindings
{
    public static readonly Dictionary<KeyActions, (ConsoleKey Key, string Description)> Actions = new()
    {
        { KeyActions.MoveUp,     (ConsoleKey.W, "move up") },
        { KeyActions.MoveDown,   (ConsoleKey.S, "move down") },
        { KeyActions.MoveLeft,   (ConsoleKey.A, "move left") },
        { KeyActions.MoveRight,  (ConsoleKey.D, "move right") },
        { KeyActions.PickupItem, (ConsoleKey.E, "pick up item") },
        { KeyActions.DropItem,   (ConsoleKey.Q, "drop item") },
        { KeyActions.EquipItem,  (ConsoleKey.F, "equip item") },
        { KeyActions.SelectInventoryDown, (ConsoleKey.DownArrow, "select inventory down")},
        { KeyActions.SelectInventoryUp, (ConsoleKey.UpArrow, "select inventory up")},
    };
}