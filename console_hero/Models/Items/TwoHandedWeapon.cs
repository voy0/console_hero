namespace console_hero.Models.Items;

public abstract class TwoHandedWeapon(char symbol, string name, int damage): Item(symbol, name), IEquippable,  IWeapon
{
    public int BaseDamage { get; } = damage;
    public override bool UseFromInventory(Player player)
    {
        return Equip(player); 
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
    public void Attack(){}
}

public class GreatSword(char symbol, string name, int damage) : TwoHandedWeapon(symbol, name, damage);