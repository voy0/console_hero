namespace console_hero.Generation;

public interface IAbstractDungeonThemeFactory
{
    string GetWelcomeMessage();
    List<Func<IItem>>  GetArtifact();
    
    List<Func<IItem>> GetItemsList();
    List<Func<IWeapon>> GetWeaponsList();
    List<Func<Enemy>> GetEnemiesList();

    Level GenerateLayout(DungeonDirector director);
}       