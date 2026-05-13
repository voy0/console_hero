using console_hero.Events;

namespace console_hero;

public abstract class Enemy : IObserver
{
    public char Symbol { get; }
    public string Name { get; }
    public string Color { get; }
    public string ColoredSymbol { get; }
    public string ColoredName { get; }
    public ResourceAttribute Health { get; }
    public IAttribute Armor { get; }
    public IAttribute Damage { get; }
    public Guild GuildType { get; }
    public int MovementSpeed { get; } = 10;
    public int GetEffectiveMovementSpeed() => (int)(MovementSpeed * (1 + (GuildObject?.MovementBonus() ?? 0)));
    public int GetEffectiveDamage() => (int)(Damage.Value * (GuildObject?.DamageBonus() ?? 1));
    public int GetEffectiveArmor() => (int)(Armor.Value * (GuildObject?.ArmorBonus() ?? 1));
    private IGuild? _guildObject;
    public IGuild? GuildObject{
        get => _guildObject;
        set
        {
            _guildObject = value;
            
            if (_guildObject != null)
            {
                double initialHealthMultiplier = _guildObject.HealthBonus();
                Health.Scale(initialHealthMultiplier);
            }
        }
    }
    public bool IsDead => Health.IsEmpty;
    public (int x, int y) Position;
    public bool InFight = false;
    public Enemy(Guild guild, char symbol, string name, string color, int health, int armor, int damage)
    {
        GuildType = guild;
        Symbol = symbol;
        Name = name;
        Color = color;
        ColoredSymbol = $"{color}{symbol}{Ansi.Reset}";
        ColoredName = $"{color}{name}{Ansi.Reset}";

        Health = new ResourceAttribute(health);
        Armor = new CoreAttribute(armor);
        Damage = new CoreAttribute(damage);
        SubscribeToEvents();
    }
    public void SubscribeToEvents()
    {
        GameEventManager.Instance.Subscribe(EventType.EnemyDied, this);
        GameEventManager.Instance.Subscribe(EventType.Noise, this);
    }
    public void OnNotify(GameEvent ev)
    {
        if (ev.Type == EventType.EnemyDied)
        {
            if (this.GuildObject != null && ev.Guild == this.GuildType && !this.IsDead)
            {
                GameLogger.Instance.Log($"{Name} senses the slaughter of their kin (Population of {GuildObject.Guild}: {GuildObject.Population})");
                double newHealthMultiplier = GuildObject.HealthBonus();
                Health.Scale(newHealthMultiplier); 
            }
        }

        if (ev.Type == EventType.Noise)
        {
            if (ev.Map == null)
            {
                throw new ArgumentException();
            }
            int distance = SoundPathfinder.GetDistance(ev.Map, ev.Position, this.Position, ev.Intensity);

            if (distance != -1 && distance <= ev.Intensity)
            {
                GameLogger.Instance.Log($"{Name} at (x: {this.Position.x}, y: {this.Position.y}) heard the noise from  {distance} tiles away, at (x: {ev.Position.x}, y: {ev.Position.y})");
                // this.State = EnemyState.Hunting;
            }
        }
    }
    public void UnsubscribeFromEvents()
    {
        GameEventManager.Instance.Unsubscribe(EventType.EnemyDied, this);
        GameEventManager.Instance.Unsubscribe(EventType.Noise, this);
    }
}
// necropolis: damage+ armor+ health+ movement-

public class Undead( ) : Enemy(Guild.Necropolis,'u', "Undead", Ansi.FgRgb(100, 230, 205), 120, 2, 11);
public class Ghoul( ) : Enemy(Guild.Necropolis,'&', "Ghoul", Ansi.FgRgb(150,220,170), 75, 0, 19);
public class Spirit( ) : Enemy(Guild.Necropolis,'9', "Spirit", Ansi.FgRgb(170, 140, 220), 99, 0, 26);
public class DarkMage() : Enemy(Guild.Necropolis, '7', "Dark Mage", Ansi.FgRgb(200, 140, 220), 177, 0, 47);

// horde: movement+ health-
public class Orc() : Enemy(Guild.Horde,'8', "Orc", Ansi.FgRgb(140,250,140), 180, 8, 24);
public class Goblin( ) : Enemy(Guild.Horde,'g', "Goblin", Ansi.FgRgb(100, 250, 100), 55, 0, 8);
public class GoblinGiant( ) : Enemy(Guild.Horde,'B', "Goblin Giant", Ansi.FgRgb(50, 200, 50), 300, 10, 18);

// fey: 2-1 *damage- movement- 2-1 *health-
public class Elf( ) : Enemy(Guild.Fey,'f', "Elf", Ansi.FgRgb(160, 250, 50), 30, 0, 6);
public class WarriorElf() : Enemy(Guild.Fey,'F', "Warrior Elf", Ansi.FgRgb(160, 200, 50), 55, 0, 17);


// Beasts damage+ movement+
public class MutantRat() : Enemy(Guild.Beasts, 'Q', "Mutant Rat", Ansi.FgRgb(150,150,180), 45, 0,15);
public class Werewolf( ): Enemy(Guild.Beasts,'M', "Werewolf",  Ansi.FgRgb(180,180,180), 125, 0, 26);
public class Chimera( ) : Enemy(Guild.Beasts,'H', "Chimera", Ansi.FgRgb(150, 180, 150), 280, 0, 36);

// unaffiliated

public class Golem() : Enemy(Guild.None,'@', "Golem", Ansi.FgRgb(255,255,100), 225, 25, 25);
public class Behemoth() : Enemy(Guild.None,'B', "Behemoth", Ansi.FgRgb(255, 255, 100), 666, 13, 99);

public static class EnemiesLists
{
    public static List<Func<Enemy>> Necropolis => new()
    {
        () => new Undead(),
        () => new Ghoul(),
        () => new Spirit(),
        () => new DarkMage()
    };

    public static List<Func<Enemy>> Horde => new()
    {
        () => new Orc(),
        () => new Goblin(),
        () => new GoblinGiant()
    };

    public static List<Func<Enemy>> Fey => new()
    {
        () => new Elf(),
        () => new WarriorElf()
    };

    public static List<Func<Enemy>> Beasts => new()
    {
        () => new MutantRat(),
        () => new Werewolf(),
        () => new Chimera()
    };

    public static List<Func<Enemy>> Unaffiliated => new()
    {
        () => new Golem(),
        () => new Golem(),
        () => new Golem(),
        () => new Golem(),
        () => new Behemoth()
    };
} 
