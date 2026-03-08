namespace console_hero;

public class MovePlayerCommand : ICommand
{
    GameState _gameState;
    Player _player;
    Map _map;
    private int dx, dy;
    public MovePlayerCommand(GameState gameState, int dx, int dy)
    {
        _gameState = gameState;
        _player = _gameState.Player;
        _map = _gameState.Map;
        this.dx = dx;
        this.dy = dy;
    }
    public void Execute()
    {
        var currentPos = _player.Position;
        (int x, int y) newPos  = (currentPos.x + dx, currentPos.y + dy);
        if (newPos.x < _map.Width &&
            newPos.x >= 0 &&
            newPos.y < _map.Height &&
            newPos.y >= 0 &&
            !_map.Cells[newPos.x, newPos.y].IsWall)
        {
            _player.Move(dx, dy);
        }
    }
}