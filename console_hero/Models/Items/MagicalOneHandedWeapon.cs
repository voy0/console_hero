namespace console_hero.Models.Items;

public abstract class MagicalOneHandedWeapon(char symbol, string name, int damage, int magic)
    : OneHandedWeapon(symbol, name, damage), IMagical
{
    public int Magic { get; } = magic;
}

public class Wand() : MagicalOneHandedWeapon('¡', "Magical Wand", 1, 6);