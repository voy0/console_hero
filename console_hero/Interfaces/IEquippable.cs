namespace console_hero;

public enum EquipSlot
{
    MainHand,
    OffHand,
    TwoHand
}
public interface IEquippable : IItem
{
    EquipSlot Slot { get; }
}