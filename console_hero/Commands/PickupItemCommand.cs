namespace console_hero;

public class PickupItemCommand : ICommand
{
    Player  _player;
    Map  _map;

    public PickupItemCommand(Player player, Map map)
    {
        _player = player;
        _map = map;
    }

    public void Execute()
    {
        (int x, int y) = _player.Position;
        var items = _map.Cells[x, y].Items;
        
        if (items.Count == 0) return;

        var item = items.Pop();
        item.Pickup(_player);
        
    }
}