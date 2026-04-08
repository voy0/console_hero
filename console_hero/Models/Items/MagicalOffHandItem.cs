namespace console_hero.Models.Items;

public abstract class MagicalOffHandItem(char symbol, string name, string color, int damage, int statModifier, StatType stat): OffHandItem(symbol, name, color, damage, statModifier, stat)
{
}

public class Grimoire() : MagicalOffHandItem('§', "The Grimore", Ansi.FgRgb(200, 30, 200), 0, 15, StatType.Magic)
{
    public override (int damage, int defense) Accept(ICombatVisitor visitor, Player player, IEquippable outerItem)
    {
        return visitor.VisitNonWeapon(outerItem, player);
    }
}