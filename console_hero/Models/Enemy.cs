namespace console_hero;

public abstract class Enemy
{
    public char Symbol { get; }
    public string Name { get; }
    public string Color { get; }
    public string ColoredSymbol { get; }
    public string ColoredName { get; }
    public ResourceAttribute Health { get; }
    public IAttribute Armor { get; }
    public IAttribute Damage { get; }
    public bool IsDead => Health.IsEmpty;
    
    public Enemy(char symbol, string name, string color, int health, int armor, int damage)
    {
        Symbol = symbol;
        Name = name;
        Color = color;
        ColoredSymbol = $"{color}{symbol}{Ansi.Reset}";
        ColoredName = $"{color}{name}{Ansi.Reset}";

        Health = new ResourceAttribute(health);
        Armor = new CoreAttribute(armor);
        Damage = new CoreAttribute(damage);
    }
}

public class MutantRat() : Enemy('☙', "Mutant Rat", Ansi.FgRgb(255,255,255), 20, 0, 5);