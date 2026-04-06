namespace console_hero.Actions;

public class NormalAttackVisitor: ICombatVisitor
{
    public (int damage, int defense) VisitLightWeapon(IEquippable weapon, Player player)
    {
        double damage = weapon.BaseDamage;
        
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = player.GetTotalStat(StatType.Luck);
        double strength = player.GetTotalStat(StatType.Strength);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        double intellect = player.GetTotalStat(StatType.Intellect);
            
        if (player.Hands.Left == player.Hands.Right)
            dexterity *= 2;

        damage = damage * (agility + luck + strength / 3 + dexterity + intellect / 3) / 10;
        
        int armor =  player.GetTotalStat(StatType.Armor);

        int defense = (int)(dexterity * 0.5 + agility * 1.5) + armor + (int)luck;
        
        return ((int)Math.Max(1, damage), defense);
    }

    public (int damage, int defense) VisitHeavyWeapon(IEquippable weapon, Player player)
    {
        double damage = weapon.BaseDamage;
        
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = player.GetTotalStat(StatType.Luck);
        double strength = player.GetTotalStat(StatType.Strength);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        double intellect = player.GetTotalStat(StatType.Intellect);


        if (player.Hands.Left == player.Hands.Right)
            dexterity *= 1.5;

        damage = damage * (agility / 2 + luck / 2 + 2 * strength + dexterity + intellect / 3) / 10;
        
        int armor =  player.GetTotalStat(StatType.Armor);
        
        int defense = (int)(strength*1.5 + dexterity*0.5) + armor + (int)luck;

        return ((int)Math.Max(1, damage), defense);
    }

    public (int damage, int defense) VisitMagicWeapon(IEquippable weapon, Player player)
    {
        int damage = 1;
        
        int armor = player.GetTotalStat(StatType.Armor);
        int defense = armor; 
        
        return (damage, defense);
    }

    public (int damage, int defense) VisitNonWeapon(IEquippable weapon, Player player)
    {
        int damage = 0;
        int defense = player.GetTotalStat(StatType.Dexterity);
        return (damage, defense);
    }
}

public class StealthAttackVisitor : ICombatVisitor
{
    public (int damage, int defense) VisitLightWeapon(IEquippable weapon, Player player)
    {
        double damage = weapon.BaseDamage;
        
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = player.GetTotalStat(StatType.Luck);
        double strength = player.GetTotalStat(StatType.Strength);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        double intellect = player.GetTotalStat(StatType.Intellect);
            
        if (player.Hands.Left == player.Hands.Right && player.Hands.Left != null)
            dexterity *= 2;

        damage = (damage * (agility + luck + strength / 3 + dexterity + intellect / 3) / 10) * 2.0;
        
        int armor = player.GetTotalStat(StatType.Armor);

        int defense = (int)(dexterity * 1.5 + agility * 1.5) + armor;
        
        return ((int)Math.Max(1, damage), defense);
    }

    public (int damage, int defense) VisitHeavyWeapon(IEquippable weapon, Player player)
    {
        double damage = weapon.BaseDamage;
        
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = player.GetTotalStat(StatType.Luck);
        double strength = player.GetTotalStat(StatType.Strength);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        double intellect = player.GetTotalStat(StatType.Intellect);

        if (player.Hands.Left == player.Hands.Right && player.Hands.Left != null)
            dexterity *= 1.5;

        damage = (damage * (agility / 2 + luck / 2 + 2 * strength + dexterity + intellect / 3) / 10) * 0.5;
        
        int armor = player.GetTotalStat(StatType.Armor);
        
        int defense = (int)strength + armor;

        return ((int)Math.Max(1, damage), defense);
    }

    public (int damage, int defense) VisitMagicWeapon(IEquippable weapon, Player player)
    {
        int damage = 1;
        
        int armor = player.GetTotalStat(StatType.Armor);
        int defense = armor; 
        
        return (damage, defense);
    }

    public (int damage, int defense) VisitNonWeapon(IEquippable weapon, Player player)
    {
        int armor = player.GetTotalStat(StatType.Armor);
        return (0, armor); 
    }
}

public class MagicAttackVisitor : ICombatVisitor
{
    public (int damage, int defense) VisitLightWeapon(IEquippable weapon, Player player)
    {
        int damage = 1;
        
        int armor = player.GetTotalStat(StatType.Armor);
        double luck = player.GetTotalStat(StatType.Luck);
        
        int defense = armor + (int)luck; 
        
        return (damage, defense);
    }

    public (int damage, int defense) VisitHeavyWeapon(IEquippable weapon, Player player)
    {
        int damage = 1; 
        
        int armor = player.GetTotalStat(StatType.Armor);
        double luck = player.GetTotalStat(StatType.Luck);
        
        int defense = armor + (int)luck; 
        
        return (damage, defense);
    }

    public (int damage, int defense) VisitMagicWeapon(IEquippable weapon, Player player)
    {
        double damage = weapon.BaseDamage;
        
        double magic = player.GetTotalStat(StatType.Magic);
        double luck = player.GetTotalStat(StatType.Luck);
        double intellect = player.GetTotalStat(StatType.Intellect);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        
        if (player.Hands.Left == player.Hands.Right && player.Hands.Left != null)
            dexterity *= 1.2;

        damage = damage * (magic + luck + dexterity + intellect) / 10;
        
        int armor = player.GetTotalStat(StatType.Armor);
        
        int defense = armor + (int)(intellect * 2 + magic);
        
        return ((int)Math.Max(1, damage), defense);
    }

    public (int damage, int defense) VisitNonWeapon(IEquippable weapon, Player player)
    {
        int armor = player.GetTotalStat(StatType.Armor);
        double luck = player.GetTotalStat(StatType.Luck);
        return (0, armor + (int)luck);
    }
}