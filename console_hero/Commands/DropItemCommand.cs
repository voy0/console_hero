namespace console_hero;

public class DropItemCommand(Player player, Map map, InventoryMenu inventoryMenu) : ICommand
{

    public void Execute()
    {
        if (player.Inventory.IsEmpty) return;
        var itemToDrop = player.Inventory.Items[inventoryMenu.CurrentIndex];
        
        player.Inventory.Items.Remove(itemToDrop);
        map.Cells[player.Position.x, player.Position.y].Items.Push(itemToDrop);
        inventoryMenu.ValidateIndex();
    }
}