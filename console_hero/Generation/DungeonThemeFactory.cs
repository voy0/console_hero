using console_hero.Models.Items;

namespace console_hero.Generation;

public class LibraryDungeonThemeFactory : IAbstractDungeonThemeFactory
{
    private string _welcomeMessage = "The air is filled with strange magical power (Library)";

    public List<Func<IItem>> GetItemsList() => new List<Func<IItem>>()
    {
        () => new TornBook(),
        () => new DeadRat(),
        () => new Relic(),
        () => new Grimoire(),
    };

    public List<Func<IWeapon>> GetWeaponsList() => new List<Func<IWeapon>>()
    {
        () => new Wand(),
        () => new ShortSword(),
        () => new GrandStaff()
    };

    public List<List<Func<Enemy>>> GetEnemiesLists() => new()
    {
        EnemiesLists.Fey,
    };

    public List<Func<IItem>> GetArtifact() => new List<Func<IItem>>()
    {
        () => new ForbiddenPage(),
    };
    public string GetWelcomeMessage() => _welcomeMessage;

    public Level GenerateLayout(DungeonDirector director)
    {
        return director.LibraryDungeon(this);
    }
}
public class CatacombsDungeonThemeFactory : IAbstractDungeonThemeFactory
{
    private string _welcomeMessage = "The stench of decomposing bodies is unbearable (Catacombs)";

    public List<Func<IItem>> GetItemsList() => new List<Func<IItem>>()
    {
        () => new DeadRat(),
        () => new Sand(),
        () => new Bones(),
        () => new BodyParts(),
        () => new TuscanShield(),
        () => new Relic()
    };

    public List<Func<IWeapon>> GetWeaponsList() => new List<Func<IWeapon>>()
    {
        () => new KnightsSword(),
        () => new TwinDaggers(),
    };

    public List<List<Func<Enemy>>> GetEnemiesLists() => new()
    {
        EnemiesLists.Necropolis
    };

    public List<Func<IItem>> GetArtifact() => new List<Func<IItem>>()
    {
        () => new JesusFigner(),
    };
    public string GetWelcomeMessage() => _welcomeMessage;

    public Level GenerateLayout(DungeonDirector director)
    {
        return director.CatacombsDungeon(this);
    }
}
public class ArmoryDungeonThemeFactory : IAbstractDungeonThemeFactory
{
    private string _welcomeMessage = "You can feel the aura of mythical armies that were preparing for battle (Armory)";

    public List<Func<IItem>> GetItemsList() => new List<Func<IItem>>()
    {
        () => new DeadRat(),
        () => new TargeShield(),
        () => new TuscanShield(),
    };

    public List<Func<IWeapon>> GetWeaponsList() => new List<Func<IWeapon>>()
    {
        () => new ShortSword(),
        () => new KnightsSword(),
        () => new TwinDaggers(),
        () => new GreatSword(),
    };

    public List<List<Func<Enemy>>> GetEnemiesLists() => new()
    {
        EnemiesLists.Horde,
        EnemiesLists.Beasts,
    };

    public List<Func<IItem>> GetArtifact() => new List<Func<IItem>>()
    {
        () => new SecretStiletto(),
    };
    public string GetWelcomeMessage() => _welcomeMessage;

    public Level GenerateLayout(DungeonDirector director)
    {
        return director.ArmoryDungeon(this);
    }
}
public class TestDungeonFactory : IAbstractDungeonThemeFactory
{
    private string _welcomeMessage = "Testing is fun (Test Dungoen)";

    public List<Func<IItem>> GetItemsList() => new List<Func<IItem>>()
    {
        () => new TargeShield(),
        () => new TuscanShield(),
        () => new Grimoire(),
    };

    public List<Func<IWeapon>> GetWeaponsList() => new List<Func<IWeapon>>()
    {
        () => new Wand(),
        () => new ShortSword(),
        () => new KnightsSword(),
        () => new GrandStaff(),
        () => new TwinDaggers(),
        () => new GreatSword(),
    };

    public List<List<Func<Enemy>>> GetEnemiesLists() => new()
    {
        EnemiesLists.Necropolis,
        EnemiesLists.Horde,
        EnemiesLists.Fey,
        EnemiesLists.Beasts,
        EnemiesLists.Unaffiliated
    };

    public List<Func<IItem>> GetArtifact() => new List<Func<IItem>>()
    {
        () => new SecretStiletto(),
        () => new JesusFigner(),
    };
    public string GetWelcomeMessage() => _welcomeMessage;

    public Level GenerateLayout(DungeonDirector director)
    {
        return director.TestDungeon(this);
    }
}