namespace console_hero;

public interface IWeapon : IItem, IEquippable
{
    int BaseDamage{get;}
    //void Attack();
}