namespace console_hero;

public class Player
{
    public Player(int x = 0, int y = 0, IProfession profession = null)
    {
        Position = (x, y);
        Stats =  new CharacterStats(profession ?? new BaseProfession());
    }
    public CharacterStats Stats {get;}
    public (int x, int y) Position { get; private set; }

    public void Move(int dx, int dy)
    {
        Position = (Position.x + dx, Position.y + dy);
    }
}