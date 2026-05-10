namespace console_hero;
public enum Guild
{
    None,
    Necropolis,
    Horde,
    Fey,
    Beasts
}

public interface IGuild
{
    int Population { get; set; }
    Guild Guild { get; }
    double DamageBonus();
    double MovementBonus();
    double ArmorBonus();
    double HealthBonus();
}

public class Necropolis : IGuild
{
    public int OriginalPopulation { get; }
    public int Population { get; set; }
    public Guild Guild => Guild.Necropolis;
    public Necropolis(int initialPopulation)
    {
        OriginalPopulation = initialPopulation;
        Population = initialPopulation;
    }
    public double DamageBonus()
    {
        if (Population == 0) return 0;
        return (double) OriginalPopulation /  Population;
    }

    public double MovementBonus()
    {
        if (Population == 0) return 0;
        return (double) Population /OriginalPopulation;
    }
    public double ArmorBonus()
    {
        if (Population == 0) return 0;
        return (double) OriginalPopulation /  Population;
    }

    public double HealthBonus()
    {
        if (Population == 0) return 0;
        return (double) OriginalPopulation /  Population;
    }
}

public class Horde : IGuild
{
    public int OriginalPopulation { get; }
    public int Population { get; set; }
    public Guild Guild => Guild.Horde;
    public Horde(int initialPopulation)
    {
        OriginalPopulation = initialPopulation;
        Population = initialPopulation;
    }
    public double DamageBonus()
    {
        return 0;
    }

    public double MovementBonus()
    {
        if (Population == 0) return 0;
        return (double) OriginalPopulation /  Population; // increases as the population drops
    }
    public double ArmorBonus()
    {
        return 0;
    }
    public double HealthBonus()
    {
        if (Population == 0) return 0;
        return (double)  Population / OriginalPopulation;
    }
}
public class Fey : IGuild
{
    public int OriginalPopulation { get; }
    public int Population { get; set; }
    public Guild Guild => Guild.Fey;
    public Fey(int initialPopulation)
    {
        OriginalPopulation = initialPopulation;
        Population = initialPopulation;
    }
    public double DamageBonus()
    {
        if (Population == 0) return 0;
        return (double)(Population + OriginalPopulation) / OriginalPopulation;
    }

    public double MovementBonus()
    {
        if (Population == 0) return 0;
        return (double) Population / OriginalPopulation ;
    }
    public double ArmorBonus()
    {
        return 0;
    }

    public double HealthBonus()
    {
        if (Population == 0) return 0;
        return (double)  (Population + OriginalPopulation) / OriginalPopulation;
    }
}
public class Wolves : IGuild
{
    public int OriginalPopulation { get; }
    public int Population { get; set; }
    public Guild Guild => Guild.Beasts;
    public Wolves(int initialPopulation)
    {
        OriginalPopulation = initialPopulation;
        Population = initialPopulation;
    }
    public double DamageBonus()
    {
        if (Population == 0) return 0;
        return (double) OriginalPopulation /  Population;
    }

    public double MovementBonus()
    {
        if (Population == 0) return 0;
        return (double) OriginalPopulation /  Population;
    }
    public double ArmorBonus()
    {
        return 0;
    }

    public double HealthBonus()
    {
        return 0;
    }
}