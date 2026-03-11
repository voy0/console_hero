namespace console_hero.Models.Items;

public abstract class MagicalOneHandedWeapon(char symbol, string name, int damage, int magic)
    : OneHandedWeapon(symbol, name, damage), IMagical
{
    public int Magic { get; } = magic;
}

public class Wand(char symbol, string name, int damage, int magic) : MagicalOneHandedWeapon(symbol, name, damage, magic);