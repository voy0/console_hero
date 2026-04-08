namespace console_hero;

public class BareHands : IEquippable
{
    public string Name => "Bare Hands";
    public string ColoredName => Name;
    public char Symbol => ' ';
    public string Color => "";
    public string ColoredSymbol => " ";
    public int BaseDamage { get; } = 0;
    public List<KeyActions> AvailableActions => new();
    
    public bool Equip(Player player, IEquippable itemToEquip) => false;
    public int GetStatBonus(StatType statType) => 0;
    public bool Pickup(Player p) => false;
    public bool UseFromInventory(Player player) => false;

    public (int damage, int defense) Accept(ICombatVisitor visitor, Player player, IEquippable outerItem)
    {
        return visitor.VisitNonWeapon(this, player);
    }
}