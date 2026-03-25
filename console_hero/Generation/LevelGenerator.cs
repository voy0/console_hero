using console_hero.Generation;

namespace console_hero;

public class LevelGenerator : ILevelGenerator
{
    public Level Generate()
    {
        return DungeonDirector.ArmoryDungeon();
    }
}