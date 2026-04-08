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
    public (int x, int y) Position;
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

public class MutantRat() : Enemy('Q', "Mutant Rat", Ansi.FgRgb(230,230,255), 35, 0, 8);
public class Ghoul() : Enemy('Ó', "Ghoul", Ansi.FgRgb(230,230,255), 75, 0, 27);
public class Golem() : Enemy('8', "Golem", Ansi.FgRgb(255,255,230), 225, 5, 10);
public class Orc() : Enemy('B', "Orc", Ansi.FgRgb(255,230,230), 180, 12, 12);

