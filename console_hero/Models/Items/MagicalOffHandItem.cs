namespace console_hero.Models.Items;

public abstract class MagicalOffHandItem(char symbol, string name, int magic): OffHandItem(symbol, name), IMagical
{
    public int Magic { get; } = magic;
}

public class Grimoire(char symbol, string name, int magic) : MagicalOffHandItem(symbol, name, magic);