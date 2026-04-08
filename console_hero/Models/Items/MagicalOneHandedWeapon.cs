namespace console_hero.Models.Items;

public abstract class MagicalOneHandedWeapon(char symbol, string name, string color, int damage, int magic)
    : OneHandedWeapon(symbol, name, color, damage)
{
    public override int GetStatBonus(StatType statType)
    {
        if (statType == StatType.Magic)
        {
            return magic;
        }

        return 0;
    }
}

public class Wand() : MagicalOneHandedWeapon('¡', "Magical Wand", Ansi.FgRgb(170, 20, 240), 1, 6), IMagicalWeapon
{
    public override (int damage, int defense) Accept(ICombatVisitor visitor, Player player, IEquippable outerItem)
    {
        return visitor.VisitMagicWeapon(outerItem, player);
    }
}