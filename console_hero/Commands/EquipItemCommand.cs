namespace console_hero;

public class EquipItemCommand(Player player, Map map, InventoryMenu inventoryMenu) : ICommand
{
    public void Execute()
    {
        if (player.Inventory.IsEmpty || !inventoryMenu.InFocus) return; 
        
        var invItem = player.Inventory.Items[inventoryMenu.CurrentIndex];
        if (invItem.UseFromInventory(player))
        {
            GameLogger.Instance.Log($"Equipped {invItem.Name}");
        }
        
        inventoryMenu.ValidateIndex();
    }
}