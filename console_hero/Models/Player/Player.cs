namespace console_hero;

public class Player
{
    public Player(int x = 1, int y = 1, IProfession profession = null)
    {
        Position = (x, y);
        Stats =  new CharacterStats(profession ?? new Hero());
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
    
    public int GetTotalStat(StatType stat)
    {
        int baseValue = Stats[stat].Value;

        int leftBonus = Hands.Left?.GetStatBonus(stat) ?? 0;
        int rightBonus = Hands.Right?.GetStatBonus(stat) ?? 0;
         

        if (Hands.Left != null && Hands.Left == Hands.Right)
        {
            return baseValue + leftBonus; 
        }

        return baseValue + leftBonus + rightBonus;
    }
}