namespace console_hero.Models.Items;
public static class EntityGenerator
{
    public static IItem GenerateRandomWeapon()
    {
        int r = Random.Shared.Next(100);
        if (r < 25) return new KnightsSword();
        if (r < 50) return new TargeShield();
        if (r < 55) return new GreatSword();
        if (r < 80) return new Wand();
        if (r < 90) return new GrandStaff();
        return new Grimoire();
    }

    public static IItem GenerateRandomItem()
    {
        int r = Random.Shared.Next(100);
        if (r < 40) return new Sand();
        if (r < 80) return new DeadRat();
        if (r < 98) return new Bones();
        return new JesusFigner();
    }

    public static Enemy GenerateRandomEnemy()
    {
        int r = Random.Shared.Next(100);

        return new MutantRat();
    }
}