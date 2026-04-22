namespace console_hero.Generation;

public class DungeonDirector(GameState gameState)
{
    public Level LibraryDungeon(IAbstractDungeonThemeFactory theme)
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.FullDungeon(81, 31)
            .AddCorridors()
            .AddCenterRoom(13)
            .AddCoins(60, 20)
            .AddGold(10, 1)
            .AddWeapons(theme.GetWeaponsList(), 30)
            .AddItems(theme.GetItemsList(), 30)
            .AddEnemies(theme.GetEnemiesList(), 25)
            .AddArtifact(theme.GetArtifact())
            .AddPrompt(theme.GetWelcomeMessage())
            .Build(gameState);
    }
    public Level CatacombsDungeon(IAbstractDungeonThemeFactory theme)
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.FullDungeon(81, 31)
            .AddCorridors()
            .AddRooms(10)
            .AddCoins(20, 50)
            .AddGold(5, 1)
            .AddWeapons(theme.GetWeaponsList(), 20)
            .AddItems(theme.GetItemsList(), 30)
            .AddEnemies(theme.GetEnemiesList(), 45)
            .AddArtifact(theme.GetArtifact())
            .AddPrompt(theme.GetWelcomeMessage())
            .Build(gameState);
    }
    public Level ArmoryDungeon(IAbstractDungeonThemeFactory theme)
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.FullDungeon(51, 36)
            .AddCorridors()
            .AddCenterRoom(17)
            .AddCoins(10, 50)
            .AddGold(4, 5)
            .AddWeapons(theme.GetWeaponsList(), 30)
            .AddItems(theme.GetItemsList(), 35)
            .AddEnemies(theme.GetEnemiesList(), 45)
            .AddArtifact(theme.GetArtifact())
            .AddPrompt(theme.GetWelcomeMessage())
            .Build(gameState);
    }
    public Level TestDungeon(IAbstractDungeonThemeFactory theme)
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.EmptyDungeon(81, 36)
            .AddCoins(10, 50)
            .AddGold(4, 5)
            .AddWeapons(theme.GetWeaponsList(), 2000)
            .AddItems(theme.GetItemsList(), 35)
            .AddEnemies(theme.GetEnemiesList(), 50)
            .AddArtifact(theme.GetArtifact())
            .AddPrompt(theme.GetWelcomeMessage())
            .Build(gameState);
    }
}