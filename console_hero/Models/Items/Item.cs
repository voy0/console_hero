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
        throw new NotImplementedException();
    }
}