namespace console_hero;

public class Hero : IProfession
{
    public string Name { get; } = "Hero";

    public IReadOnlyDictionary<StatType, int> InitialStats { get; } = new Dictionary<StatType, int>
    {
        { StatType.Health, 100 },
        { StatType.Mana, 100 },
        { StatType.Stamina, 100 },
        
        { StatType.Armor, 10 },
        { StatType.Strength, 10 },
        { StatType.Agility, 10 },
        { StatType.Dexterity, 10 },
        
        { StatType.Intellect, 10 },
        { StatType.Luck, 10 },
        { StatType.Magic, 10 }
    };
}
public class Mage : IProfession
{
    public string Name { get; } = "Mage";

    public IReadOnlyDictionary<StatType, int> InitialStats { get; } = new Dictionary<StatType, int>
    {
        { StatType.Health, 75 },
        { StatType.Mana, 100 },
        { StatType.Stamina, 20 },
        
        { StatType.Armor, 0 },
        { StatType.Strength, 2 },
        { StatType.Agility, 5 },
        { StatType.Dexterity, 7 },
        
        { StatType.Intellect, 10 },
        { StatType.Luck, 7 },
        { StatType.Magic, 12 }
    };
}
public class Thief : IProfession
{
    public string Name { get; } = "Thief";

    public IReadOnlyDictionary<StatType, int> InitialStats { get; } = new Dictionary<StatType, int>
    {
        { StatType.Health, 125 },
        { StatType.Mana, 30 },
        { StatType.Stamina, 100 },
        
        { StatType.Armor, 3 },
        { StatType.Strength, 4 },
        { StatType.Agility, 12 },
        { StatType.Dexterity, 9 },
        
        { StatType.Intellect, 7 },
        { StatType.Luck, 5 },
        { StatType.Magic, 2 }
    };
}
public class Warrior : IProfession
{
    public string Name { get; } = "Warrior";

    public IReadOnlyDictionary<StatType, int> InitialStats { get; } = new Dictionary<StatType, int>
    {
        { StatType.Health, 165 },
        { StatType.Mana, 20 },
        { StatType.Stamina, 60 },
        
        { StatType.Armor, 9 },
        { StatType.Strength, 14 },
        { StatType.Agility, 6 },
        { StatType.Dexterity, 8 },
        
        { StatType.Intellect, 1 },
        { StatType.Luck, 2 },
        { StatType.Magic, 1 }
    };
}
public class LuckyGuy : IProfession
{
    public string Name { get; } = "LuckyGuy";

    public IReadOnlyDictionary<StatType, int> InitialStats { get; } = new Dictionary<StatType, int>
    {
        { StatType.Health, 100 },
        { StatType.Mana, 20 },
        { StatType.Stamina, 60 },
        
        { StatType.Armor, 9 },
        { StatType.Strength, 14 },
        { StatType.Agility, 6 },
        { StatType.Dexterity, 8 },
        
        { StatType.Intellect, 1 },
        { StatType.Luck, 2000 },
        { StatType.Magic, 1 }
    };
}
// TODO: make enemy and player derive from entity and profession so combat is more realistic
// public class EnemyMutantRat : IProfession
// {
//     public string Name { get; } = "Rat";
//     
// }