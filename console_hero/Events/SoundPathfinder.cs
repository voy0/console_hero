namespace console_hero.Events;

public static class SoundPathfinder
{
    private static (int x, int y) _lastNoiseSource = (-1, -1);
    private static int[,] _distanceCache = new int[0, 0];
    private static Map? _lastMap = null;

    public static int GetDistance(Map map, (int x, int y) source, (int x, int y) target, int maxRange)
    {
        if (target.x < 0 || target.x >= map.Width || target.y < 0 || target.y >= map.Height) 
            return -1;

        if (_lastNoiseSource != source || _lastMap != map)
        {
            if (_distanceCache.GetLength(0) != map.Width || _distanceCache.GetLength(1) != map.Height)
            {
                _distanceCache = new int[map.Width, map.Height];
            }
            
            CalculateBFS(map, source, maxRange);
            
            _lastNoiseSource = source; 
            _lastMap = map;
        }

        return _distanceCache[target.x, target.y];
    }

    private static void CalculateBFS(Map map, (int x, int y) start, int maxRange)
    {
        for (int i = 0; i < map.Width; i++)
        {
            for (int j = 0; j < map.Height; j++)
            {
                _distanceCache[i, j] = -1;
            }
        }

        if (start.x < 0 || start.x >= map.Width || start.y < 0 || start.y >= map.Height) 
            return;

        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
        queue.Enqueue(start);
        _distanceCache[start.x, start.y] = 0;

        int[] dx = { 0, 0, 1, -1 };
        int[] dy = { 1, -1, 0, 0 };

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int currentDist = _distanceCache[current.x, current.y];

            if (currentDist >= maxRange) continue;

            for (int i = 0; i < 4; i++)
            {
                int nx = current.x + dx[i];
                int ny = current.y + dy[i];

                if (nx >= 0 && nx < map.Width && ny >= 0 && ny < map.Height)
                {
                    if (!map.Cells[nx, ny].IsWall && _distanceCache[nx, ny] == -1)
                    {
                        _distanceCache[nx, ny] = currentDist + 1; 
                        queue.Enqueue((nx, ny));
                    }
                }
            }
        }
    }
}