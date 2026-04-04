namespace console_hero;

public interface IWeapon : IItem, IEquippable
{
    int BaseDamage{get;}
    int GetStatBonus(StatType statType);
    //void Attack();
}