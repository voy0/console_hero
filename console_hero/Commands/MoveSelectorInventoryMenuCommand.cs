namespace console_hero;

public class MoveSelectorInventoryMenuCommand(InventoryMenu inventoryMenu, bool moveUp) : ICommand
{
    public void Execute()
    {
        if (moveUp)
        {
            inventoryMenu.GoUp();
        }
        else
        {
            inventoryMenu.GoDown();
        }
    }
}