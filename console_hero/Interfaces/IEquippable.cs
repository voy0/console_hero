namespace console_hero;

public interface IEquippable : IItem
{
    bool Equip(Player player);
}