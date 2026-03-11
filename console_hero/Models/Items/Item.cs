namespace console_hero.Models.Items;

public abstract class Item : IItem
{
    public char Symbol { get; }
    public string Name { get; }
    public virtual bool Pickup(Player player) => player.Inventory.AddItem(this);

    public Item(char symbol, string name)
    {
        Symbol = symbol;
        Name = name;
    }

    public virtual bool UseFromInventory(Player player)
    {
        return false;
    }
}

public class Sand(char symbol, string name) : Item(symbol, name);
public class Bones(char symbol, string name) : Item(symbol, name);
public class DeadRat(char symbol, string name) : Item(symbol, name);
