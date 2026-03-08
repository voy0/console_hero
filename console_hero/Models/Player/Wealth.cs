namespace console_hero;

public class Wealth
{
    public int Coins { get; private set; }
    public int Gold { get; private set; }

    public void AddCoins(int amount)
    {
        Coins += amount;
    }

    public void AddGold(int amount)
    {
        Gold += amount;
    }
    public Wealth(int coins = 0, int gold = 0)
    {
        Coins = coins;
        Gold = gold;
    }
}