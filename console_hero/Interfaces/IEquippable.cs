namespace console_hero;

public interface IEquippable : IItem
{
    bool Equip(Player player, IEquippable itemToEquip);
    int GetStatBonus(StatType statType, Player player);
    (int damage, int defense) Accept(ICombatVisitor visitor, Player player, IEquippable outerItem);
    int BaseDamage { get; }
}