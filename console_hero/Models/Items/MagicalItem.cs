namespace console_hero.Models.Items;

public abstract class MagicalItem(char symbol, string name, int magic) : Item(symbol, name), IMagical
{
    public int Magic => magic;
}

public class JesusFigner(char symbol, string name, int magic) : MagicalItem(symbol, name, magic);