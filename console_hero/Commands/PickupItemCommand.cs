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
        var cell = _map.Cells[x, y];
        
        if (cell.ItemsCount == 0) return;
        
        var item = cell.PeekItem();
        if (item.Pickup(_player))
        {
            cell.PopItem();
            GameLogger.Instance.Log($"Picked up {item.Name}");
        }
    }
}