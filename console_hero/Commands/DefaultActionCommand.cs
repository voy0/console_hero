namespace console_hero;

public class DefaultActionCommand(GameState gameState): ICommand
{
    public void Execute()
    {
        GameLogger.Instance.Log("Pressed an unbided button");
    }
}