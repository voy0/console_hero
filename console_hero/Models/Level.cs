namespace console_hero;

public class Level
{
    public Map Map { get; set; }
    public List<KeyActions> KeyActionsList { get; set; }
    public List<Enemy> Enemies { get; set; } = new List<Enemy>();

    public Level(Map map, List<KeyActions> keyActionsList)
    {
        Map = map;
        KeyActionsList = keyActionsList;
    }
    
    public void AddEnemy(Enemy enemy, int x, int y)
    {
        Enemies.Add(enemy);
        Map.Cells[x, y].Occupant = enemy;
    }

    public void RemoveEnemy(Enemy enemy)
    {
        Enemies.Remove(enemy);
        Map.Cells[enemy.Position.x, enemy.Position.y].Occupant = null;
    }
}