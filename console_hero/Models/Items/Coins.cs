namespace console_hero.Models.Items;

public class Coins(int amount) : Item('c', "Coins"), ICurrency
{
    public int Value { get; } = amount;

    public override bool Pickup(Player p)
    {
        p.Wealth.AddCoins(Value);
        return true;
    }
    
}