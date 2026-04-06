namespace console_hero;

public interface IEquippable : IItem
{
    bool Equip(Player player, IEquippable itemToEquip);
    int GetStatBonus(StatType statType);
    int BaseDamage { get; }
}