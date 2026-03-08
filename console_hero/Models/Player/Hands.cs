namespace console_hero;

public class Hands
{
    public IEquippable? LeftHand { get; private set; }
    public IEquippable? RightHand  { get; private set; }

    public IEquippable? EquipRight(IEquippable item)
    {
        IEquippable? rightHandItem = RightHand;
        RightHand = item;
        return rightHandItem;
    }

    public IEquippable? EquipLeft(IEquippable item)
    {
        IEquippable? leftHandItem = LeftHand;
        LeftHand = item;
        return leftHandItem;
    }

    public IEquippable? ReleaseFromLeftHand()
    {
        IEquippable? item = RightHand;
        RightHand = null;
        return item;
    }

    public IEquippable? ReleaseFromRightHand()
    {
        IEquippable? item = LeftHand;
        LeftHand = null;
        return item;
    }
}