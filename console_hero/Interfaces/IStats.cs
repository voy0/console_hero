namespace console_hero;

public interface IStats
{
    IResourceAttribute Health { get; }
    IResourceAttribute Mana { get; }
    IResourceAttribute Stamina { get; }
    
    IAttribute Agility { get; } 
    IAttribute Strength { get; }
    IAttribute Dexterity { get; }
    
    IAttribute Intelligence { get; }
    IAttribute Luck { get; }
    IAttribute Magic { get; }

    IReadOnlyDictionary<string, IAttribute> AttributesMap { get; }
}