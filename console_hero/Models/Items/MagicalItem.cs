namespace console_hero.Models.Items;

public abstract class MagicalItem(char symbol, string name, int magic) : Item(symbol, name), IMagical
{
    public int Magic => magic;
}

public class JesusFigner() : MagicalItem('ļ', "The Jesus Finger", 67);