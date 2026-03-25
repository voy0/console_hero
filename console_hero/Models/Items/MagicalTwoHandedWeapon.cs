namespace console_hero.Models.Items;

public abstract class MagicalTwoHandedWeapon(char symbol, string name, int damage, int magic)
    : TwoHandedWeapon(symbol, name, damage), IMagical
{
    public int Magic { get; } = magic;
}
public class GrandStaff() : MagicalTwoHandedWeapon('ƒ', "The Grand Staff", 3, 8);
