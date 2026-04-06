namespace console_hero.Models.Items;
public static class EntityGenerator
{
    public static IItem GenerateRandomWeapon()
    {
        int r = Random.Shared.Next(100);
        if (r < 25) return new KnightsSword();
        if (r < 50) return new TargeShield();
        if (r < 55) return new GreatSword();
        if (r < 80) return new TwinDaggers();
        if (r < 90) return new Wand();
        if (r < 95) return new GrandStaff();
        return new Grimoire();
    }

    public static IWeapon GenrateRandomDecoratedWeapon()  
    {
        int r = Random.Shared.Next(100);
        IWeapon weapon;
        if (r < 40) weapon = new KnightsSword();
        else if (r < 60) weapon = new GreatSword();
        else if (r < 80) weapon = new TwinDaggers();
        else if (r < 95) weapon = new Wand();
        else weapon = new GrandStaff();
        if (Random.Shared.Next(100) < 50)
        {
            // if (Random.Shared.Next(100) < 80) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.I);
            // else if (Random.Shared.Next(100) < 40) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.II);
            // else if (Random.Shared.Next(100) < 15) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.III);
            // else if (Random.Shared.Next(100) < 7) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.IV);
            // else if (Random.Shared.Next(100) < 2) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.V);
            
            // if (Random.Shared.Next(100) < 50) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.I);
            // else if (Random.Shared.Next(100) < 50) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.II);
            // else if (Random.Shared.Next(100) < 50) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.III);
            // else if (Random.Shared.Next(100) < 50) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.IV);
            // else if (Random.Shared.Next(100) < 50) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.V);
            
            if (Random.Shared.Next(100) < 90) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.I);
            else if (Random.Shared.Next(100) < 60) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.II);
            else if (Random.Shared.Next(100) < 30) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.III);
            else if (Random.Shared.Next(100) < 15) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.IV);
            else if (Random.Shared.Next(100) < 5) weapon = new GradeWeaponDecorator(weapon, WeaponGrade.V);
        }

        r =  Random.Shared.Next(100);
        if (r < 7) weapon = new LuckyWeaponDecorator(weapon);
        return weapon;
    }

    public static IItem GenerateRandomItem()
    {
        int r = Random.Shared.Next(1000);
        if (r < 400) return new Sand();
        if (r < 800) return new DeadRat();
        if (r < 999) return new Bones();
        return new JesusFigner();
    }

    public static Enemy GenerateRandomEnemy()
    {
        int r = Random.Shared.Next(100);

        return new MutantRat();
    }
}