namespace console_hero;

public class EquipItemCommand(Player player, Map map, InventoryMenu inventoryMenu) : ICommand
{
    public void Execute()
    {
        if (player.Inventory.IsEmpty) return;
        
        var invItem = player.Inventory.Items[inventoryMenu.CurrentIndex];
        invItem.UseFromInventory(player);
        
        inventoryMenu.ValidateIndex();
    }
}