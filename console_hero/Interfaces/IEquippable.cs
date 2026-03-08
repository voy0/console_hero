namespace console_hero;

public interface IEquippable : IItem
{
    bool Equip(Player player);
    bool UnEquip(Player player);
}