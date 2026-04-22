namespace console_hero.Models.Items;

public abstract class Item : IItem
{
    public char Symbol { get; }
    public string Name { get; }
    public string Color { get; }
    public string ColoredSymbol { get; }
    public string ColoredName { get; }
    public virtual List<KeyActions> AvailableActions => new List<KeyActions>() { KeyActions.PickupItem, KeyActions.DropItem };
    public virtual bool Pickup(Player player) => player.Inventory.AddItem(this);
    public virtual int GetStatBonus(StatType statType, Player player) => 0;

    public Item(char symbol, string name, string color)
    {
        Symbol = symbol;
        Name = name;
        Color = color;
        ColoredSymbol = $"{color}{symbol}{Ansi.Reset}";
        ColoredName = $"{color}{name}{Ansi.Reset}";
    }

    public virtual bool UseFromInventory(Player player)
    {
        return false;
    }
}

public class Sand() : Item('≅', "Sand", Ansi.FgRgb(100,100,20));
public class Bones() : Item('%', "Bones", Ansi.FgRgb(100, 100, 100));
public class DeadRat() : Item('ò', "Dead Rat",  Ansi.FgRgb(120, 20, 20));
public class BodyParts() : Item('#', "Rotting Body Parts", Ansi.FgRgb(80, 120, 40));
public class TornBook() : Item('M', "Torn Book", Ansi.FgRgb(120, 120, 20));

