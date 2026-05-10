namespace console_hero.Models.Items;
public static class EntityGenerator
{
    public static IItem GenerateRandomWeapon()
    {
        int r = Random.Shared.Next(100);
        if (r < 25) return new KnightsSword();
        if (r < 45) return new ShortSword();
        if (r < 55) return new TargeShield();
        if (r < 60) return new GreatSword();
        if (r < 80) return new TwinDaggers();
        if (r < 90) return new Wand();
        if (r < 93) return new GrandStaff();
        return new Grimoire();
    }

    public static IWeapon GenerateRandomDecoratedWeapon()  
    {
        int r = Random.Shared.Next(100);
        IWeapon weapon;
        if (r < 25) weapon = new KnightsSword();
        else if (r < 50) weapon = new ShortSword();
        else if (r < 60) weapon = new GreatSword();
        else if (r < 80) weapon = new TwinDaggers();
        else if (r < 95) weapon = new Wand();
        else weapon = new GrandStaff();

        RandomDecorateWeapon(weapon);
        return weapon;
    }

    public static IWeapon RandomDecorateWeapon(IWeapon weapon)
    {
        if (Random.Shared.Next(100) < 20)
        {
            if (Random.Shared.Next(100) < 5) weapon = new LuckyWeaponDecorator(weapon);

            if (Random.Shared.Next(100) < 60) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.I);
            else if (Random.Shared.Next(100) < 50) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.II);
            else if (Random.Shared.Next(100) < 40) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.III);
            else if (Random.Shared.Next(100) < 30) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.IV);
            else if (Random.Shared.Next(100) < 15) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.V);
        }

        return weapon;
    }
    public static IWeapon GenerateRandomDecoratedWeapon(List<Func<IWeapon>> items)
    {
        foreach (var item in items)
        {
            int r = Random.Shared.Next(2);
            if (r == 1) return RandomDecorateWeapon(item());
        }
        return items[0]();
    }
    

    public static IItem GenerateRandomItem()
    {
        int r = Random.Shared.Next(1000);
        if (r < 400) return new Sand();
        if (r < 800) return new DeadRat();
        if (r < 999) return new Bones();
        return new JesusFigner();
    }
    public static IItem GenerateRandomItem(List<Func<IItem>> items)
    {
        foreach (var item in items)
        {
            int r = Random.Shared.Next(2);
            if (r == 1) return item();
        }
        return items[0]();
    }

    public static Enemy GenerateRandomEnemy()
    {
        int r = Random.Shared.Next(100);
        if (r < 20) return new Golem();
        if (r < 40) return new Orc();
        if (r < 60) return new Ghoul();
        return new MutantRat();
    }

    public static Enemy GenerateRandomEnemy(List<Func<Enemy>> enemies)
    {
        foreach (var enemy in enemies)
        {
            int r = Random.Shared.Next(3);
            if (r == 0) return enemy();
        }
        return enemies[0]();
    }
}