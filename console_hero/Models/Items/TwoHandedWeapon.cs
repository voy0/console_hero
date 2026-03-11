namespace console_hero.Models.Items;

public class TwoHandedWeapon : IEquippable, IWeapon
{
    public char Symbol { get; }
    public string Name { get; }
    public int BaseDamage { get; }
    public EquipSlot Slot { get; } = EquipSlot.TwoHand;

    public TwoHandedWeapon(char symbol, string name, int damage)
    {
        Symbol = symbol;
        Name = name;
        BaseDamage = damage;
    }
    
    public bool Pickup(Player player)
    {
        return player.Inventory.AddItem(this);
    }
    
    public bool Equip(Player player)
    {
        int itemsToDrop = 0;
        if (player.Hands.Left != null) itemsToDrop++;
        if (player.Hands.Right != null && player.Hands.Right != player.Hands.Left) itemsToDrop++;
        
        if (player.Inventory.Count - 1 + itemsToDrop > player.Inventory.Capacity)
        {
            return false;
        }
        IEquippable? itemFromRight = player.Hands.EquipRight(this);
        IEquippable? itemFromLeft = player.Hands.EquipLeft(this);
        player.Inventory.RemoveItem(this);

        if (itemFromRight == itemFromLeft)
        {
            player.Inventory.AddItem(itemFromRight);
            return true;
        }
        player.Inventory.AddItem(itemFromRight);
        player.Inventory.AddItem(itemFromLeft);

        return true;
    }
}