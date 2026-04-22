namespace console_hero.Models.Items;

public abstract class MagicalOffHandItem(char symbol, string name, string color, int damage, int statModifier, StatType stat, StatType corelatedStat): OffHandItem(symbol, name, color, damage, statModifier, stat, corelatedStat)
{
}

public class Grimoire() : MagicalOffHandItem('§', "The Grimore", Ansi.FgRgb(200, 30, 200), 0, 8, StatType.Magic, StatType.Intellect) 
{
    public override (int damage, int defense) Accept(ICombatVisitor visitor, Player player, IEquippable outerItem)
    {
        return visitor.VisitNonWeapon(outerItem, player);
    }
}
