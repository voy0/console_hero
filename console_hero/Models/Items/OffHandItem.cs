namespace console_hero.Models.Items;

public abstract class OffHandItem(char symbol, string name, string color): Item(symbol, name, color), IEquippable
{
    public override List<KeyActions> AvailableActions => new List<KeyActions>() { KeyActions.DropItem, KeyActions.EquipItem };
    
    public override bool UseFromInventory(Player player)
    {
        return Equip(player, this); 
    }
    public bool Equip(Player player, IEquippable itemToEquip)
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

        player.Hands.EquipLeft(itemToEquip);
        player.Inventory.RemoveItem(itemToEquip);
        
        player.Inventory.AddItem(item);
        return true;
    }
}

public class TargeShield() : OffHandItem('O', "The Targe Shield", Ansi.FgRgb(50, 150, 100));