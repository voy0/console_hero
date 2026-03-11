namespace console_hero.Models.Items;

public class OffHandItem(char symbol, string name, int value) : IEquippable
{
    public char Symbol { get; } = symbol;
    public string Name { get; } = name;
    public int Value { get; } = value;
    public EquipSlot Slot { get; } = EquipSlot.OffHand;

    public bool Pickup(Player player)
    {
        return player.Inventory.AddItem(this);
    }

    public bool Equip(Player player)
    {
        IEquippable? item = null;
        if (player.Hands.Left == player.Hands.Right)
        {
            item = player.Hands.ReleaseFromLeft();
            player.Hands.ReleaseFromRight();
        }
        else
        {
            item = player.Hands.ReleaseFromLeft();
        }

        player.Hands.EquipLeft(this);
        player.Inventory.RemoveItem(this);
        
        player.Inventory.AddItem(item);
        return true;
    }
}