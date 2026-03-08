using System.Collections.Generic;

namespace console_hero;

public class CharacterStats : IStats
{
    public IResourceAttribute Health { get; }
    public IResourceAttribute Mana { get; }
    public IResourceAttribute Stamina { get; }
    
    public IAttribute Agility { get; } 
    public IAttribute Strength { get; } 
    public IAttribute Dexterity { get; } 
    
    public IAttribute Intelligence { get; } 
    public IAttribute Luck { get; } 
    public IAttribute Magic { get; } 

    public IReadOnlyDictionary<string, IAttribute> AttributesMap { get; }

    public CharacterStats(IProfession profession)
    {
        Health = new ResourceAttribute(0, 0, profession.BaseHealth);
        Mana = new ResourceAttribute(0, 0, profession.BaseMana);
        Stamina = new ResourceAttribute(0, 0, profession.BaseStamina);
        
        Agility = new CoreAttribute(profession.BaseAgility);
        Strength = new CoreAttribute(profession.BaseStrength);
        Dexterity = new CoreAttribute(profession.BaseDexterity);
        Intelligence = new CoreAttribute(profession.BaseIntelligence);
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
            { "Intelligence", Intelligence },
            { "Luck", Luck },
            { "Magic", Magic }
        };
    }
}