namespace console_hero;

public class BaseProfession : IProfession
{
    public string Name { get; } = "Hero";

    public int BaseHealth { get; } = 100;
    public int BaseMana { get; } = 101;
    public int BaseStamina { get; } = 102;

    public int BaseAgility { get; } = 10;
    public int BaseDexterity { get; } = 11;
    public int BaseStrength { get; } = 12;

    public int BaseIntelligence { get; } = 13;
    public int BaseLuck { get; } = 14;
    public int BaseMagic { get; } = 15;
}