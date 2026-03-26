namespace console_hero.Models.Items;

public class Coins(int amount) : Item('©', "Coins", Ansi.FgRgb(200, 150, 80)), ICurrency
{
    public int Value { get; } = amount;

    public override bool Pickup(Player p)
    {
        p.Wealth.AddCoins(Value);
        return true;
    }
    
}