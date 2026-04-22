namespace console_hero.Models.Items;

public abstract class OffHandItem(char symbol, string name, string color, int damage, int statModifier, StatType stat, StatType corelatedStat): Item(symbol, name, color), IEquippable
{
    public override List<KeyActions> AvailableActions => new List<KeyActions>() { KeyActions.DropItem, KeyActions.EquipItem };
    
    public override bool UseFromInventory(Player player)
    {
        return Equip(player, this); 
    }

    public int BaseDamage { get; } = damage;

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
            item = player.Hands.ReleaseFromLeft();
        }

        player.Hands.EquipLeft(itemToEquip);
        player.Inventory.RemoveItem(itemToEquip);
        
        player.Inventory.AddItem(item);
        return true;
    }
    public override int GetStatBonus(StatType statType, Player player)
    {
        if (statType == stat)
        {
        var coStat = (double)player.GetTotalStat(corelatedStat);
            double requiredStat = 10.0; 

            double efficiency = Math.Min(1.0, coStat / requiredStat);

            return (int)(statModifier * efficiency);
        }

        return 0;
    }
    public abstract (int damage, int defense) Accept(ICombatVisitor visitor, Player player, IEquippable outerItem);
}

public class TargeShield() : OffHandItem('O', "The Targe Shield", Ansi.FgRgb(50, 150, 100), 1, 6, StatType.Armor, StatType.Dexterity)
{
    public override (int damage, int defense) Accept(ICombatVisitor visitor, Player player, IEquippable outerItem)
    {
        return visitor.VisitNonWeapon(outerItem, player);
    }
}
public class TuscanShield() : OffHandItem('0', "The Tuscan Shield", Ansi.FgRgb(50, 190, 100), 1, 9, StatType.Armor, StatType.Dexterity)
{
    public override (int damage, int defense) Accept(ICombatVisitor visitor, Player player, IEquippable outerItem)
    {
        return visitor.VisitNonWeapon(outerItem, player);
    }
}