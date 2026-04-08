namespace console_hero;

public class ChangeMenuFocusCommand(GameState gameState) : ICommand
{
    public void Execute()
    {
        gameState.Menus.FocusNext();
    }
}

