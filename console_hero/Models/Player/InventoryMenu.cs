namespace console_hero;

public class InventoryMenu(Inventory inventory)
{
    public int CurrentIndex { get; private set; }

    public void GoUp()
    {
        if (inventory.Count == 0) return;
        int newIndex = CurrentIndex - 1;
        CurrentIndex = (newIndex < 0) ? inventory.Count - 1 : newIndex;
    }

    public void GoDown()
    {
        if (inventory.Count == 0) return;
        CurrentIndex = (CurrentIndex + 1) % inventory.Count;
    }

    public void ValidateIndex()
    {
        if (inventory.Count == 0)
        {
            CurrentIndex = 0;
            return;
        }
        if (CurrentIndex >= inventory.Count)
        {
            CurrentIndex = inventory.Count - 1;
        }
    }
}