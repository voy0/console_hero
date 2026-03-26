namespace console_hero.Models.Items;

public abstract class MagicalOffHandItem(char symbol, string name, string color, int magic): OffHandItem(symbol, name, color), IMagical
{
    public int Magic { get; } = magic;
}

public class Grimoire() : MagicalOffHandItem('§', "The Grimore", Ansi.FgRgb(200, 30, 200), 10);