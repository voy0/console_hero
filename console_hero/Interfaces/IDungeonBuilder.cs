namespace console_hero;

public interface IDungeonBuilder
{
    void Reset();
    IDungeonBuilder AddCorridors();
    IDungeonBuilder AddRooms(int rooms);
    IDungeonBuilder AddCenterRoom(int size);
    IDungeonBuilder AddItems(List<Func<IItem>> items, int n);
    IDungeonBuilder AddWeapons(List<Func<IWeapon>> weapons, int n);
    IDungeonBuilder AddCoins(int coins, int denomination = 100);
    IDungeonBuilder AddGold(int gold, int denomination = 5);
    IDungeonBuilder AddEnemies(List<Func<Enemy>> enemies, int n);
    IDungeonBuilder AddArtifact(List<Func<IItem>> artifact);
    IDungeonBuilder AddPrompt(string prompt);
    
    Level Build(GameState gameState);
}