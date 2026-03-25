namespace console_hero;

public class DefaultActionCommand(GameState gameState): ICommand
{
    public void Execute()
    {
        gameState.Prompts.Add("This button doest do anything!");
    }
}