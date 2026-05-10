using console_hero.Events;

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
            int noiseIntensity = item switch
            {
                IHeavyWeapon => 15,   
                ILightWeapon => 5,     
                IMagicalWeapon => 10,      
                _ => 2                
            };

            if (noiseIntensity > 0)
            {
                GameEventManager.Instance.Notify(new GameEvent(EventType.Noise, _map, (x, y), noiseIntensity));
            }
        }
    }
}