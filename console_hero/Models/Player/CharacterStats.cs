using System.Collections.Generic;

namespace console_hero;

public enum StatType
{
    Health,
    Mana,
    Stamina,
    Armor,
    Strength,
    Agility,
    Dexterity,
    Intellect,
    Luck,
    Magic
}
public class CharacterStats 
{
    public IReadOnlyDictionary<StatType, IAttribute> AttributesMap { get; }

    public IAttribute this[StatType stat] => AttributesMap[stat];

    public IResourceAttribute Health => (IResourceAttribute)AttributesMap[StatType.Health];
    public IResourceAttribute Mana => (IResourceAttribute)AttributesMap[StatType.Mana];
    public IResourceAttribute Stamina => (IResourceAttribute)AttributesMap[StatType.Stamina];

    public CharacterStats(IProfession profession)
    {
        var map = new Dictionary<StatType, IAttribute>();

        foreach (var kvp in profession.InitialStats)
        {
            if (kvp.Key is StatType.Health or StatType.Mana or StatType.Stamina)
            {
                map[kvp.Key] = new ResourceAttribute(kvp.Value);
            }
            else
            {
                map[kvp.Key] = new CoreAttribute(kvp.Value);
            }
        }

        AttributesMap = map;
    }
}