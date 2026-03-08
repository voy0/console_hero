namespace console_hero;

public class Inventory
{
    public bool IsFull => Items.Count == Capacity;
    public int Capacity { get; private set; }
    public List<IItem> Items { get; private set; }
    public Inventory(int capacity = 10)
    {
        Capacity = capacity;
        Items = new List<IItem>();
    }

    public bool AddItem(IItem? item)
    {
        if (Items.Count == Capacity || item == null) return false;
        Items.Add(item);
        return true;
    }
    public bool RemoveItem(IItem item)
    {
        return Items.Remove(item);;
    }
}