namespace console_hero;

public interface IProfession
{
    string Name { get; }
    
    int BaseHealth { get; }
    int BaseMana { get; }
    int BaseStamina { get; }
    
    int BaseAgility { get; }
    int BaseDexterity { get; }
    int BaseStrength { get; }
    
    int BaseIntelligence { get; }
    int BaseLuck{ get; }
    int BaseMagic { get; }
}