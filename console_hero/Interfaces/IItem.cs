namespace console_hero;

public interface IItem
{
    char Symbol { get;}
    string Name { get; }
    string Color { get; }
    string ColoredSymbol { get; }
    string ColoredName { get; }
    List<KeyActions> AvailableActions { get; }
    public int GetStatBonus(StatType statType);
    
    bool Pickup(Player player);
    bool UseFromInventory(Player player);
}