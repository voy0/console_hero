namespace console_hero;

public class InventoryRenderer(Player player, InventoryMenu inventoryMenu) : IModuleRenderer
{
    public int Height { get; set; } = player.Inventory.Capacity+1;
    private List<string> _inventoryLines = new List<string>();
    public void Render()
    {
        _inventoryLines.Clear();
        var inventory  = player.Inventory;
        _inventoryLines.Add($"== ({inventory.Count}/{inventory.Capacity}) == I N V E N T O R Y ===");
        for (int i = 0; i < inventory.Count; i++)
        {
            string? arrow = null;
            if (inventoryMenu.CurrentIndex == i && inventoryMenu.InFocus)
            {
                arrow = $"{Ansi.BgWhite}{Ansi.FgBlack}>";
            }
            var item = inventory.Items[i];
            _inventoryLines.Add($"{arrow} {i + 1}.{Ansi.Reset} {item.ColoredSymbol} {item.ColoredName}");
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