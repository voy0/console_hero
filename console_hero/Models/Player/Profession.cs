namespace console_hero;

public class Hero : IProfession
{
    public string Name { get; } = "Hero";

    public IReadOnlyDictionary<StatType, int> InitialStats { get; } = new Dictionary<StatType, int>
    {
        { StatType.Health, 100 },
        { StatType.Mana, 100 },
        { StatType.Stamina, 100 },
        
        { StatType.Armor, 2 },
        { StatType.Strength, 2 },
        { StatType.Agility, 2 },
        { StatType.Dexterity, 2 },
        
        { StatType.Intellect, 2 },
        { StatType.Luck, 2 },
        { StatType.Magic, 2 }
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
        { StatType.Strength, 0 },
        { StatType.Agility, 1 },
        { StatType.Dexterity, 1 },
        
        { StatType.Intellect, 5 },
        { StatType.Luck, 2 },
        { StatType.Magic, 6 }
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
        
        { StatType.Armor, 1 },
        { StatType.Strength, 3 },
        { StatType.Agility, 4 },
        { StatType.Dexterity, 3 },
        
        { StatType.Intellect, 1 },
        { StatType.Luck, 2 },
        { StatType.Magic, 1 }
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
        
        { StatType.Armor, 5 },
        { StatType.Strength, 7 },
        { StatType.Agility, 1},
        { StatType.Dexterity, 2 },
        
        { StatType.Intellect, 0 },
        { StatType.Luck, 0 },
        { StatType.Magic, 0 }
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