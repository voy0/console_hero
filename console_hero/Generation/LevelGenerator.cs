using console_hero.Generation;

namespace console_hero;

public class LevelGenerator(GameState gameState) : ILevelGenerator
{
    public Level Generate()
    {
        DungeonDirector director = new DungeonDirector(gameState);
        return director.TreasureDungeon();
    }
}