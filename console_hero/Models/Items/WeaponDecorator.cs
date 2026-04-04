namespace console_hero.Models.Items;

public abstract class WeaponDecorator : IWeapon
{
    protected readonly IWeapon _weapon;

    public WeaponDecorator(IWeapon weapon)
    {
        _weapon = weapon;
    }
    public virtual string Name => _weapon.Name;
    public virtual char Symbol => _weapon.Symbol;
    public virtual string Color => _weapon.Color;
    public virtual string ColoredSymbol => _weapon.ColoredSymbol;
    public virtual string ColoredName => _weapon.ColoredName;

    public virtual int BaseDamage => _weapon.BaseDamage;
    public virtual int GetStatBonus(StatType stat) => _weapon.GetStatBonus(stat);

    public virtual List<KeyActions> AvailableActions => _weapon.AvailableActions;
    public virtual bool Pickup(Player p)
    {
        return p.Inventory.AddItem(this);
    }
    public virtual bool UseFromInventory(Player player)
    {
        return _weapon.Equip(player, this);
    }

    public virtual bool Equip(Player p, IEquippable weapon)
    {
        return _weapon.Equip(p, weapon);
    }
}

public enum WeaponGrade
{
    I,
    II,
    III,
    IV,
    V,
}

public class GradeWeaponDecorator : WeaponDecorator
{
    private WeaponGrade _grade;
    private (string color, int damageBonus) _gradeValues;
    private static readonly Dictionary<WeaponGrade, (string color, int damageBonus)> GradeColors = new()
    {
        { WeaponGrade.I, (Ansi.FgRgb(0, 225, 225), 2) },
        { WeaponGrade.II, (Ansi.FgRgb(50, 150, 255), 4) },
        { WeaponGrade.III, (Ansi.FgRgb(255, 150, 50), 7) },
        { WeaponGrade.IV, (Ansi.FgRgb(255, 25, 125), 9) },
        { WeaponGrade.V, (Ansi.FgRgb(255, 25, 0), 12) },
    };

    public GradeWeaponDecorator(IWeapon weapon, WeaponGrade grade) : base(weapon)
    {
        _grade = grade;
        _gradeValues = GradeColors[_grade]; 
    }
    
    public override string Name => $"{_weapon.Name} ({_grade.ToString()})";
    public override string Color => $"{_gradeValues.color}";
    public override string ColoredName => $"{_weapon.ColoredName} {_gradeValues.color}({_grade.ToString()}){Ansi.Reset}";
    public override string ColoredSymbol => $"{_gradeValues.color}{_weapon.Symbol}{Ansi.Reset}";
    public override int BaseDamage => _weapon.BaseDamage + _gradeValues.damageBonus; 
}

public class LuckyWeaponDecorator : WeaponDecorator
{
    public LuckyWeaponDecorator(IWeapon weapon) : base(weapon) { }

    public override string Name => $"{_weapon.Name} (Lucky)";
    public override string Color => $"{Ansi.FgRgb(0, 255, 0)}";
    public override string ColoredName => $"{_weapon.ColoredName} {Color}(Lucky){Ansi.Reset}";
    public override string ColoredSymbol => $"{Color}{_weapon.Symbol}{Ansi.Reset}";

    public override int GetStatBonus(StatType stat)
    {
        int baseBonus = _weapon.GetStatBonus(stat);

        if (stat == StatType.Luck) 
        {
            return baseBonus + 5;
        }

        return baseBonus;
    }
}