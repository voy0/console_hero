namespace console_hero.Models.Items;

public class Gold : ICurrency
{
    public char Symbol => 'g';
    public string Name => "Gold";
    public int Value { get; private set; }

    public bool Pickup(Player p)
    {
        p.Wealth.AddGold(Value);
        return true;
    }
    public Gold(int amount)
    {
        Value = amount;
    }
}