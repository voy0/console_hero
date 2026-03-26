namespace console_hero.Models.Items;

public abstract class TwoHandedWeapon(char symbol, string name, string color, int damage): Item(symbol, name, color), IEquippable,  IWeapon
{
    public int BaseDamage { get; } = damage;
    public override List<KeyActions> AvailableActions => new List<KeyActions>() { KeyActions.DropItem, KeyActions.EquipItem };
    
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

public class GreatSword() : TwoHandedWeapon('†', "The Great Sword", Ansi.FgRgb(200, 170, 170), 12);