namespace console_hero;

public class BaseProfession : IProfession
{
    public string Name { get; } = "Hero";

    public int BaseHealth { get; } = 100;
    public int BaseMana { get; } = 20;
    public int BaseStamina { get; } = 50;

    public int BaseArmor { get; } = 0;
    public int BaseStrength { get; } = 10;
    public int BaseAgility { get; } = 10;
    public int BaseDexterity { get; } = 5;

    public int BaseIntellect { get; } = 10;
    public int BaseLuck { get; } = 5;
    public int BaseMagic { get; } = 5;
}