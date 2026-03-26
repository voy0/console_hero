namespace console_hero.Models.Items;

public abstract class MagicalTwoHandedWeapon(char symbol, string name, string color, int damage, int magic)
    : TwoHandedWeapon(symbol, name, color, damage), IMagical
{
    public int Magic { get; } = magic;
}
public class GrandStaff() : MagicalTwoHandedWeapon('ƒ', "The Grand Staff", Ansi.FgRgb(255, 50, 255),3, 8);
