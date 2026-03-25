namespace console_hero;

public class Player
{
    public Player(int x = 1, int y = 1, IProfession profession = null)
    {
        Position = (x, y);
        Stats =  new CharacterStats(profession ?? new BaseProfession());
    }
    public Hands Hands = new Hands();
    public Wealth Wealth = new Wealth();
    public Inventory Inventory = new Inventory(5);
    public CharacterStats Stats {get;}
    public (int x, int y) Position { get; private set; }

    public void Move(int dx, int dy)
    {
        Position = (Position.x + dx, Position.y + dy);
    }
}