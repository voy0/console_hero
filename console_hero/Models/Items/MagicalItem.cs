namespace console_hero.Models.Items;

public abstract class MagicalItem(char symbol, string name, string color, int magic) : Item(symbol, name, color), IMagical
{
    public int Magic => magic;
}

public class JesusFigner() : MagicalItem('ļ', "The Jesus Finger", Ansi.FgRgb(255, 255, 200) ,67);