namespace console_hero;

public interface ICombatVisitor
{
    public (int damage, int defense) VisitLightWeapon(IEquippable weapon, Player player);
    public (int damage, int defense) VisitHeavyWeapon(IEquippable weapon, Player player);
    public (int damage, int defense) VisitMagicWeapon(IEquippable weapon, Player player);
    public (int damage, int defense) VisitNonWeapon(IEquippable weapon, Player player);
    
    
}