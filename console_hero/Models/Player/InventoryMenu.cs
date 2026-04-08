namespace console_hero;

public class InventoryMenu(Inventory inventory) : IMenu
{
    public int CurrentIndex { get; private set; }
    public bool InFocus { get; set; }

    public bool IsEnabled{ get{ return inventory.Count > 0; }
        set;
    }

public void GoUp()
    {
        if (inventory.Count == 0 || !InFocus) return;
        int newIndex = CurrentIndex - 1;
        CurrentIndex = (newIndex < 0) ? inventory.Count - 1 : newIndex;
    }

    public void GoDown()
    {
        if (inventory.Count == 0 || !InFocus) return;
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