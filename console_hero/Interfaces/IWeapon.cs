namespace console_hero;

public interface IWeapon : IEquippable
{
    //void Attack();
}

public interface ILightWeapon : IWeapon{}
public interface IHeavyWeapon : IWeapon{}
public interface IMagicalWeapon : IWeapon{}
