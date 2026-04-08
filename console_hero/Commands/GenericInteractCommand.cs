namespace console_hero;

public class GenericInteractCommand(GameState gameState): ICommand
{
    public void Execute()
    {
        if (gameState.Status == GameStatus.Exploration)
        {
            new EnterFightCommand(gameState).Execute();
        }
        else if (gameState.Status == GameStatus.Combat)
        {
            gameState.Combat.ExecuteSelectedAttack();
        }
    }
}