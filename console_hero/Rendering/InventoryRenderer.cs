namespace console_hero;

public class InventoryRenderer(Player player, InventoryMenu inventoryMenu) : IRenderable
{
    public int Height = player.Inventory.Capacity+1;
    private List<string> _inventoryLines = new List<string>();
    public void Render()
    {
        _inventoryLines.Clear();
        var inventory  = player.Inventory;
        _inventoryLines.Add($"== ({inventory.Count}/{inventory.Capacity}) == I N V E N T O R Y ===");
        for (int i = 0; i < inventory.Count; i++)
        {
            char? arrow = null;
            if (inventoryMenu.CurrentIndex == i)
            {
                arrow = '>';
            }
            _inventoryLines.Add($"{arrow} {i + 1}. {inventory.Items[i].Name}");
        }
    }
    public string GetLine(int y)
    {
        if (y < _inventoryLines.Count)
        {
            return "    " + _inventoryLines[y]; 
        }
        
        return ""; 
    }
}