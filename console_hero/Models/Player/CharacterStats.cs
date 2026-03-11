using System.Collections.Generic;

namespace console_hero;

public class CharacterStats : IStats
{
    public IResourceAttribute Health { get; }
    public IResourceAttribute Mana { get; }
    public IResourceAttribute Stamina { get; }
    
    public IAttribute Armor { get; }
    public IAttribute Strength { get; } 
    public IAttribute Agility { get; } 
    public IAttribute Dexterity { get; } 
    
    public IAttribute Intellect { get; } 
    public IAttribute Luck { get; } 
    public IAttribute Magic { get; } 

    public IReadOnlyDictionary<string, IAttribute> AttributesMap { get; }

    public CharacterStats(IProfession profession)
    {
        Health = new ResourceAttribute(profession.BaseHealth, 0, profession.BaseHealth);
        Mana = new ResourceAttribute(profession.BaseMana, 0, profession.BaseMana);
        Stamina = new ResourceAttribute(profession.BaseStamina, 0, profession.BaseStamina);

        Armor = new CoreAttribute(profession.BaseArmor);
        Strength = new CoreAttribute(profession.BaseStrength);
        Agility = new CoreAttribute(profession.BaseAgility);
        Dexterity = new CoreAttribute(profession.BaseDexterity);
        
        Intellect = new CoreAttribute(profession.BaseIntellect);
        Luck = new CoreAttribute(profession.BaseLuck);
        Magic = new CoreAttribute(profession.BaseMagic);

        AttributesMap = new Dictionary<string, IAttribute>
        {
            { "Health", Health },
            { "Mana", Mana },
            { "Stamina", Stamina },
            { "Agility", Agility },
            { "Strength", Strength },
            { "Dexterity", Dexterity },
            { "Intellect", Intellect },
            { "Luck", Luck },
            { "Magic", Magic }
        };
    }
}