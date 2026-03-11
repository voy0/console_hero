namespace console_hero;

public class Hands
{
    public IEquippable? Left { get; private set; }
    public IEquippable? Right  { get; private set; }

    public IEquippable? EquipRight(IEquippable item)
    {
        IEquippable? rightHandItem = Right;
        Right = item;
        return rightHandItem;
    }

    public IEquippable? EquipLeft(IEquippable item)
    {
        IEquippable? leftHandItem = Left;
        Left = item;
        return leftHandItem;
    }

    public IEquippable? ReleaseFromLeft()
    {
        IEquippable? item = Left;
        Left = null;
        return item;
    }

    public IEquippable? ReleaseFromRight()
    {
        IEquippable? item = Right;
        Right = null;
        return item;
    }
}