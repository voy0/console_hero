namespace console_hero;

using System;
using System.Collections.Generic;
using System.Linq;

public class EnemyMovementManager
{
    private GameState _gameState;
    
    private Dictionary<Enemy, (int dx, int dy)> _enemyDirections = new Dictionary<Enemy, (int dx, int dy)>();
    
    public EnemyMovementManager(GameState gameState)
    {
        _gameState = gameState;
    }

    public void MoveAllRandomly()
    {
        Level level = _gameState.Level;
        List<Enemy>? enemies = level.Enemies;
        
        if (enemies == null || enemies.Count == 0) return;

        foreach (var enemy in enemies.ToList())
        {
            if (enemy.InFight) continue;

            (int x, int y) pos = enemy.Position;
            bool movedInStraightLine = false;

            if (_enemyDirections.TryGetValue(enemy, out var currentDir))
            {
                int nextX = pos.x + currentDir.dx;
                int nextY = pos.y + currentDir.dy;

                if (IsValidMove(level.Map, nextX, nextY) && Random.Shared.Next(100) < 70)
                {
                    if (level.Map.MoveEnemy(pos.x, pos.y, nextX, nextY))
                    {
                        movedInStraightLine = true;
                    }
                }
            }

            if (!movedInStraightLine)
            {
                List<(int dx, int dy)> viableDirs = new List<(int dx, int dy)>();

                if (IsValidMove(level.Map, pos.x + 1, pos.y)) viableDirs.Add((1, 0));
                if (IsValidMove(level.Map, pos.x - 1, pos.y)) viableDirs.Add((-1, 0));
                if (IsValidMove(level.Map, pos.x, pos.y + 1)) viableDirs.Add((0, 1));
                if (IsValidMove(level.Map, pos.x, pos.y - 1)) viableDirs.Add((0, -1));

                if (viableDirs.Count > 0)
                {
                    int r = Random.Shared.Next(0, viableDirs.Count);
                    var chosenDir = viableDirs[r];
                    
                    int newX = pos.x + chosenDir.dx;
                    int newY = pos.y + chosenDir.dy;

                    if (level.Map.MoveEnemy(pos.x, pos.y, newX, newY))
                    {
                        _enemyDirections[enemy] = chosenDir;
                    }
                }
                else
                {
                    _enemyDirections.Remove(enemy);
                }
            }
        }
    }

    private bool IsValidMove(Map map, int x, int y)
    {
        if (x < 0 || x >= map.Width || y < 0 || y >= map.Height) 
            return false;

        if (!map.Cells[x, y].IsFree) 
            return false;

        if (_gameState.Player.Position.x == x && _gameState.Player.Position.y == y) 
            return false;

        return true;
    }
}