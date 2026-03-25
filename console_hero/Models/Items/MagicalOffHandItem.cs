namespace console_hero.Models.Items;

public abstract class MagicalOffHandItem(char symbol, string name, int magic): OffHandItem(symbol, name), IMagical
{
    public int Magic { get; } = magic;
}

public class Grimoire() : MagicalOffHandItem('§', "The Grimore", 10);