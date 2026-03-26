namespace console_hero.Models.Items;

public abstract class MagicalOneHandedWeapon(char symbol, string name, string color, int damage, int magic)
    : OneHandedWeapon(symbol, name, color, damage), IMagical
{
    public int Magic { get; } = magic;
}

public class Wand() : MagicalOneHandedWeapon('¡', "Magical Wand", Ansi.FgRgb(170, 20, 240),1, 6);