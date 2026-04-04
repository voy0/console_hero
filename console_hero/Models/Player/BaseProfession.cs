namespace console_hero;

public class BaseProfession : IProfession
{
    public string Name { get; } = "Hero";

    public IReadOnlyDictionary<StatType, int> InitialStats { get; } = new Dictionary<StatType, int>
    {
        { StatType.Health, 100 },
        { StatType.Mana, 100 },
        { StatType.Stamina, 100 },
        
        { StatType.Armor, 0 },
        { StatType.Strength, 10 },
        { StatType.Agility, 10 },
        { StatType.Dexterity, 5 },
        
        { StatType.Intellect, 10 },
        { StatType.Luck, 5 },
        { StatType.Magic, 5 }
    };
}
// TODO: make enemy and player derive from entity and profession so combat is more realistic
// public class EnemyMutantRat : IProfession
// {
//     public string Name { get; } = "Rat";
//     
// }