namespace console_hero.Models.Items;

public abstract class MagicalTwoHandedWeapon(char symbol, string name, string color, int damage, int magic)
    : TwoHandedWeapon(symbol, name, color, damage)
{
    public override int GetStatBonus(StatType statType, Player player)
    {
        if (statType == StatType.Magic)
        {
            return magic;
        }

        return 0;
    }
}

public class GrandStaff()
    : MagicalTwoHandedWeapon('ƒ', "The Grand Staff", Ansi.FgRgb(255, 50, 255), 2, 3), IMagicalWeapon
{
    public override (int damage, int defense) Accept(ICombatVisitor visitor, Player player, IEquippable outerItem)
    {
        return visitor.VisitMagicWeapon(outerItem, player);
    }
}
