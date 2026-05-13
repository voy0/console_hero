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
        return 1;
    }

    public double MovementBonus()
    {
        if (Population == 0) return 0;
        return (double) OriginalPopulation /  Population; // increases as the population drops
    }
    public double ArmorBonus()
    {
        return 1;
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
    private double SurvivalRatio => OriginalPopulation == 0 ? 0 : (double)Population / OriginalPopulation;
    private double ArmyScale => Math.Sqrt(OriginalPopulation);
    private double SynergyFactor => ArmyScale * SurvivalRatio;
    public double DamageBonus()
    {
        return SynergyFactor;
    }

    public double MovementBonus()
    {
        return SynergyFactor;
    }
    public double ArmorBonus()
    {
        return SynergyFactor;
    }

    public double HealthBonus()
    {
        return 1.2*SynergyFactor;
    }
}
public class Beasts : IGuild
{
    public int OriginalPopulation { get; }
    public int Population { get; set; }
    public Guild Guild => Guild.Beasts;
    public Beasts(int initialPopulation)
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
        return 1;
    }

    public double HealthBonus()
    {
        return 1;
    }
}