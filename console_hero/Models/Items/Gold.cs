namespace console_hero.Models.Items;

public class Gold(int amount) : Item('▲', "Gold"), ICurrency
{
    public int Value { get; } = amount;

    public override bool Pickup(Player p)
    {
        p.Wealth.AddGold(Value);
        return true;
    }
}