namespace console_hero;

public interface IItem
{
    char Symbol { get;}
    string Name { get; }
    List<KeyActions> AvailableActions { get; }
    bool Pickup(Player player);
    bool UseFromInventory(Player player);
}