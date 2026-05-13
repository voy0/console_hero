using console_hero.Generation;

namespace console_hero;

public class LevelGenerator(GameState gameState) 
{
    
    public Level Generate(IAbstractDungeonThemeFactory? themeFactory = null)
    {
        if (themeFactory == null)
        {
            themeFactory = new ArmoryDungeonThemeFactory();
        }
        DungeonDirector director = new DungeonDirector(gameState);
        return themeFactory.GenerateLayout(director);
    }
}