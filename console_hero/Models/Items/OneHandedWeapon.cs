namespace console_hero.Models.Items;

public class OneHandedWeapon : IEquippable, IWeapon
{
    public char Symbol { get; }
    public string Name { get; }
    public int BaseDamage { get; }

    public OneHandedWeapon(char symbol, string name, int damage)
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
        if (!player.Inventory.RemoveItem(this)) return false;
        IEquippable? item = player.Hands.EquipRight(this);
        if (item != null)
        {
            player.Inventory.AddItem(item);
        }

        return true;
    }
    public bool UnEquip(Player player)
    {
        if (player.Inventory.IsFull) return false;
        if (player.Hands.RightHand == null) return false;
        
        return player.Inventory.AddItem(player.Hands.ReleaseFromRightHand());
    }
}