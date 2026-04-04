namespace console_hero.Models.Items;

public abstract class WeaponDecorator : IWeapon
{
    public IWeapon _weapon;

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

public class SharpnessWeaponDecorator : WeaponDecorator
{
    public SharpnessWeaponDecorator(IWeapon weapon) : base(weapon) { }

    public override string Name => $"{_weapon.Name} (Sharp)";
    public override string Color => $"{Ansi.FgRgb(255,0,0)}";
    public override string ColoredName => $"{_weapon.ColoredName} {Color}(Sharp){Ansi.Reset}";
    public override string ColoredSymbol => $"{Color}{_weapon.Symbol}{Ansi.Reset}";
    public override int BaseDamage => _weapon.BaseDamage + 5; 
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