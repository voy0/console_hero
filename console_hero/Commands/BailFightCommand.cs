namespace console_hero;

public class BailFightCommand(GameState gameState) : ICommand
{
    public void Execute()
    {
        gameState.Combat.Bail();
    }
}