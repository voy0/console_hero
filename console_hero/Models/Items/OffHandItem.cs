namespace console_hero.Models.Items;

public abstract class OffHandItem(char symbol, string name): Item(symbol, name), IEquippable
{
    public override bool UseFromInventory(Player player)
    {
        return Equip(player); 
    }
    public bool Equip(Player player)
    {
        IEquippable? item = null;
        if (player.Hands.Left == player.Hands.Right)
        {
            item = player.Hands.ReleaseFromLeft();
            player.Hands.ReleaseFromRight();
        }
        else
        {
            item = player.Hands.ReleaseFromLeft();
        }

        player.Hands.EquipLeft(this);
        player.Inventory.RemoveItem(this);
        
        player.Inventory.AddItem(item);
        return true;
    }
}

public class TargeShield(char symbol, string name) : OffHandItem(symbol, name);