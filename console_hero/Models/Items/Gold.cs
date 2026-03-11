namespace console_hero.Models.Items;

public class Gold(int amount) : Item('g', "Gold"), ICurrency
{
    public int Value { get; } = amount;

    public override bool Pickup(Player p)
    {
        p.Wealth.AddGold(Value);
        return true;
    }
}