using console_hero.Actions;

namespace console_hero;

public class EnterFightCommand(GameState gameState) : ICommand
{
    public void Execute()
    {
        Player player = gameState.Player;

        Enemy? enemy = Detect.Enemy(player, gameState.Level.Map);

        if (enemy == null)
        {
            gameState.Prompts.Add("No enemy to fight");
            return;
        }

        gameState.Combat.Enter(enemy);
    }
}