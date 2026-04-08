namespace console_hero;

public class MoveSelectorInventoryMenuCommand(GameState gameState, bool moveUp) : ICommand
{
    public void Execute()
    {
        IMenu? menu = gameState.Menus.GetFocusedMenu();
        if (menu == null) return;
        menu.ValidateIndex();
        if (moveUp)
        {
            menu.GoUp();
        }
        else
        {
            menu.GoDown();
        }
    }
}