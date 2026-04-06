namespace console_hero.Actions;

public static class Detect
{
    public static Enemy? Enemy(Player player, Map map)
    {
        int x, y;
        x = player.Position.x;
        y = player.Position.y;
        if (map.Cells[x+1, y].IsOccupied)
        {
            return map.Cells[x+1, y].Occupant;
        }
        if (map.Cells[x-1, y].IsOccupied)
        {
            return map.Cells[x-1, y].Occupant;
        }
        if (map.Cells[x, y+1].IsOccupied)
        {
            return map.Cells[x, y+1].Occupant;
        }
        if (map.Cells[x, y-1].IsOccupied)
        {
            return map.Cells[x, y-1].Occupant;
        }

        return null;
    }
}