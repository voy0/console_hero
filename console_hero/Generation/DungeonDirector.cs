namespace console_hero.Generation;

public static class DungeonDirector
{
    public static Level ConnectorDungeon()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.FullDungeon()
            .AddCorridors()
            .AddCoins(20)
            .AddGold(5)
            .AddWeapons(10)
            .AddItems(20)
            .Build();
    }

    public static Level ArmoryDungeon()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.FullDungeon()
            .AddCenterRoom(10)
            .AddCorridors()
            .AddCoins(10)
            .AddGold(5)
            .AddWeapons(25)
            .AddItems(10)
            .Build();
    }

    public static Level TreasureDungeon()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.FullDungeon()
            .AddRooms(10)
            .AddCorridors()
            .AddCoins(50)
            .AddGold(25)
            .AddWeapons(3)
            .AddItems(10)
            .Build();
    }

    public static Level HallDungeon()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.EmptyDungeon()
            .AddRooms(8)
            .AddCorridors()
            .AddGold(20)
            .AddItems(10)
            .AddWeapons(2)
            .Build();
    }

    public static Level TestItems()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.EmptyDungeon()
            .AddGold(10)
            .AddCoins(10)
            .AddItems(20)
            .AddWeapons(50)
            .Build();
    }

    public static Level EmptyDungeon()
    {
        IDungeonStarter starter = new DungeonBuilder();
        return starter.EmptyDungeon()
            .Build();
    }
}