namespace console_hero.Models.Items;

public class Coins : ICurrency
{
    public char Symbol => 'c';
    public string Name => "Coins";
    public int Value { get; private set; }

    
    public Coins(int amount)
    {
        Value = amount;
    }
    public bool Pickup(Player p)
    {
        p.Wealth.AddCoins(Value);
        return true;
    }
    
}