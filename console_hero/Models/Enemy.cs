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
public class MutantRat() : Enemy('Q', "Mutant Rat", Ansi.FgRgb(220,170,150), 35, 0, 8);
public class Ghoul() : Enemy('&', "Ghoul", Ansi.FgRgb(150,220,170), 75, 0, 19);
public class Spirit() : Enemy('9', "Spirit", Ansi.FgRgb(170, 140, 220), 99, 9, 9);

public class DarkMage() : Enemy('7', "Dark Mage", Ansi.FgRgb(200, 140, 220), 177, 15, 4);
public class Undead() : Enemy('U', "Undead", Ansi.FgRgb(100, 230, 205), 120, 0, 6);
public class Orc() : Enemy('8', "Orc", Ansi.FgRgb(140,250,140), 180, 12, 12);
public class Golem() : Enemy('@', "Golem", Ansi.FgRgb(255,255,100), 225, 12, 10);


