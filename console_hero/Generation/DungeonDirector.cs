namespace console_hero.Generation;

public class DungeonDirector(GameState gameState)
{
    public Level ConnectorDungeon()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.FullDungeon()
            .AddCorridors()
            .AddCoins(20)
            .AddGold(5)
            .AddWeapons(10)
            .AddItems(20)
            .Build(gameState);
    }

    public Level ArmoryDungeon()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.FullDungeon()
            .AddCenterRoom(20)
            .AddCorridors()
            .AddCoins(10)
            .AddGold(5)
            .AddItems(10)
            .AddWeapons(25)
            .Build(gameState);
    }

    public Level TreasureDungeon()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.FullDungeon()
            .AddRooms(10)
            .AddCorridors()
            .AddCoins(50)
            .AddGold(25)
            .AddWeapons(3)
            .AddItems(10)
            .Build(gameState);
    }

    public Level HallDungeon()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.EmptyDungeon()
            .AddRooms(8)
            .AddCorridors()
            .AddGold(20)
            .AddItems(10)
            .AddWeapons(2)
            .Build(gameState);
    }

    public Level TestItems()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.EmptyDungeon()
            .AddEnemies(10)
            .AddWeapons(200)
            .Build(gameState);
    }

    public Level EmptyDungeon()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.EmptyDungeon()
            .Build(gameState);
    }

    public Level TestEnemies()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.EmptyDungeon()
            .AddEnemies(10)
            .Build(gameState);
    }
}