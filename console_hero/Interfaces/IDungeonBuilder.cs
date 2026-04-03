namespace console_hero;

public interface IDungeonBuilder
{
    void Reset();
    IDungeonBuilder AddCorridors();
    IDungeonBuilder AddRooms(int rooms);
    IDungeonBuilder AddCenterRoom(int size);
    IDungeonBuilder AddItems(int items);
    IDungeonBuilder AddWeapons(int weapons);
    IDungeonBuilder AddCoins(int coins, int denomination = 100);
    IDungeonBuilder AddGold(int gold, int denomination = 5);
    IDungeonBuilder AddEnemies(int enemies);
    Level Build(GameState gameState);
}