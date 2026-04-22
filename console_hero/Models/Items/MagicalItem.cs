namespace console_hero.Models.Items;

public abstract class MagicalItem(char symbol, string name, string color, int magic) : Item(symbol, name, color)
{
    public override int GetStatBonus(StatType statType, Player player)
    {
        if (statType == StatType.Magic)
        {
            return magic;
        }

        return 0;
    }
}
public class Relic() : MagicalItem('o', "Relic",  Ansi.FgRgb(255, 255, 200) , 2);
public class ForbiddenPage() : MagicalItem('W', "The Forbidden Page",  Ansi.FgRgb(255, 255, 200) , 10);
public class JesusFigner() : MagicalItem('ļ', "The Jesus Finger", Ansi.FgRgb(255, 255, 200), 77);
