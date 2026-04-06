namespace console_hero.Models.Items;

public abstract class OneHandedWeapon(char symbol, string name, string color, int damage): Item(symbol, name, color), IEquippable,  IWeapon
{
    public int BaseDamage { get; } = damage;
    public override List<KeyActions> AvailableActions => new List<KeyActions>() { KeyActions.DropItem, KeyActions.EquipItem };
    public override bool UseFromInventory(Player player)
    {
        return Equip(player, this); 
    }
    public bool Equip(Player player, IEquippable itemToEquip)
    {
        IEquippable? item = null;
        if (player.Hands.Left == player.Hands.Right)
        {
            item = player.Hands.ReleaseFromLeft();
            player.Hands.ReleaseFromRight();
        }
        else
        {
            item = player.Hands.ReleaseFromRight();
        }

        player.Hands.EquipRight(itemToEquip);
        player.Inventory.RemoveItem(itemToEquip);
        
        player.Inventory.AddItem(item);
        return true;
    }
    public void Attack(){}
}

public class KnightsSword() : OneHandedWeapon('⸸', "Knight's Sword", Ansi.FgRgb(150, 150, 170), 7), IHeavyWeapon;

public class ShortSword() : OneHandedWeapon('☨', "Gladius", Ansi.FgRgb(150, 150, 170), 5), ILightWeapon;
