namespace console_hero;

public class MovePlayerCommand : ICommand
{
    Player _player;
    Map _map;
    GameStatus _gameStatus;
    GameState _gameState;
    private int dx, dy;
    public MovePlayerCommand(GameState gameState, int dx, int dy)
    {
        _player = gameState.Player;
        _map = gameState.Level.Map;
        _gameStatus = gameState.Status;
        _gameState = gameState;
        this.dx = dx;
        this.dy = dy;
    }
    public void Execute()
    {
        if (_gameStatus != GameStatus.Exploration)
        {
            _gameState.Prompts.Add("To move exit the battle first");
            return;
        }
        var currentPos = _player.Position;
        (int x, int y) newPos  = (currentPos.x + dx, currentPos.y + dy);
        if (newPos.x < _map.Width &&
            newPos.x >= 0 &&
            newPos.y < _map.Height &&
            newPos.y >= 0 &&
            !_map.Cells[newPos.x, newPos.y].IsWall &&
            !_map.Cells[newPos.x, newPos.y].IsOccupied)
        {
            _player.Move(dx, dy);
        }
    }
}