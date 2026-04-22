namespace console_hero.Actions;

public class PowerAttackVisitor: ICombatVisitor
{
    public (int damage, int defense) VisitLightWeapon(IEquippable weapon, Player player)
    {
        double damage = weapon.BaseDamage;
        
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        double strength = player.GetTotalStat(StatType.Strength);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        double intellect = player.GetTotalStat(StatType.Intellect);
            
        if (player.Hands.Left == player.Hands.Right)
            dexterity *= 1.5;

        damage = damage * (agility + luck + strength / 2 + dexterity + intellect / 3) * (0.4); // 7.6
        
        int armor =  player.GetTotalStat(StatType.Armor);

        int defense = (int)((dexterity * 0.5 + agility * 0.5) + armor) + (int)luck;
        
        return ((int)Math.Max(1, damage), defense);
    }

    public (int damage, int defense) VisitHeavyWeapon(IEquippable weapon, Player player)
    {
        double damage = weapon.BaseDamage;
        
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        double strength = player.GetTotalStat(StatType.Strength);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        double intellect = player.GetTotalStat(StatType.Intellect);


        if (player.Hands.Left == player.Hands.Right)
            dexterity *= 2;

        damage = damage * (agility / 2 + luck / 2 + 2 * strength + dexterity + intellect / 3)*(0.6) + luck; // 8.6
        
        int armor =  player.GetTotalStat(StatType.Armor);
        
        int defense = (int)(strength*0.5 + dexterity*0.5) + armor + (int)luck;

        return ((int)Math.Max(1, damage), defense);
    }

    public (int damage, int defense) VisitMagicWeapon(IEquippable weapon, Player player)
    {
        int magic = player.GetTotalStat(StatType.Magic);
        int armor = player.GetTotalStat(StatType.Armor);
        int luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        int defense = magic + armor + luck; 
        
        int damage = magic;
        return (damage, defense);
    }

    public (int damage, int defense) VisitNonWeapon(IEquippable weapon, Player player)
    {
        int damage = 1;
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        int armor = player.GetTotalStat(StatType.Armor);

        int defense = (int)(0.8*(armor * 0.5 + agility * 0.5 + luck));
        return (damage, defense);
    }
}

public class StealthAttackVisitor : ICombatVisitor
{
    public (int damage, int defense) VisitLightWeapon(IEquippable weapon, Player player)
    {
        double damage = weapon.BaseDamage;
        
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        double strength = player.GetTotalStat(StatType.Strength);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        double intellect = player.GetTotalStat(StatType.Intellect);
            
        if (player.Hands.Left == player.Hands.Right && player.Hands.Left != null)
            dexterity *= 2;

        damage = damage * (2*agility + luck/3 + strength*0.5 + dexterity + intellect / 2)*(0.6) + luck; // 8.6
        
        int armor = player.GetTotalStat(StatType.Armor);

        int defense = (int)(dexterity * 0.5 + agility * 0.5) + armor + (int)luck;
        
        return ((int)Math.Max(1, damage), defense);
    }

    public (int damage, int defense) VisitHeavyWeapon(IEquippable weapon, Player player)
    {
        double damage = weapon.BaseDamage;
        
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        double strength = player.GetTotalStat(StatType.Strength);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        double intellect = player.GetTotalStat(StatType.Intellect);

        if (player.Hands.Left == player.Hands.Right && player.Hands.Left != null)
            dexterity *= 1.5;

        damage = damage * (agility / 2 + luck / 2 + strength + dexterity + intellect / 3) * (0.4); //6.6
        
        int armor = player.GetTotalStat(StatType.Armor);
        
        int defense = (int)(strength*0.5 + dexterity*0.5) + armor + (int)luck;

        return ((int)Math.Max(1, damage), defense);
    }

    public (int damage, int defense) VisitMagicWeapon(IEquippable weapon, Player player)
    {
        
        int magic = player.GetTotalStat(StatType.Magic);
        int armor = player.GetTotalStat(StatType.Armor);
        int luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        int defense = magic + armor + luck;

        int damage = magic;
        return (damage, defense);
    }

    public (int damage, int defense) VisitNonWeapon(IEquippable weapon, Player player)
    {
        int damage = 1;
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        int armor = player.GetTotalStat(StatType.Armor);

        int defense = (int)(0.8*(armor * 0.5 + agility * 0.5 + luck));
        return (damage, defense);
    }
}

public class MagicAttackVisitor : ICombatVisitor
{
    public (int damage, int defense) VisitLightWeapon(IEquippable weapon, Player player)
    {
        
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        int armor = player.GetTotalStat(StatType.Armor);
        int magic =  player.GetTotalStat(StatType.Magic);
        
        int damage = weapon.BaseDamage * magic /3;
        int defense = (int)(dexterity * 0.5 + agility * 0.5) + armor + (int)luck;
        
        return (damage, defense);
    }

    public (int damage, int defense) VisitHeavyWeapon(IEquippable weapon, Player player)
    {
        
        int armor = player.GetTotalStat(StatType.Armor);
        double luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        double strength = player.GetTotalStat(StatType.Strength);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        int magic =  player.GetTotalStat(StatType.Magic);
        
        int damage = weapon.BaseDamage * magic/3;
        int defense = (int)(strength*0.5 + dexterity*0.5) + armor + (int)luck;
        
        return (damage, defense);
    }

    public (int damage, int defense) VisitMagicWeapon(IEquippable weapon, Player player)
    {
        double damage = weapon.BaseDamage;
        
        double magic = player.GetTotalStat(StatType.Magic);
        double luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        double intellect = player.GetTotalStat(StatType.Intellect);
        double dexterity = player.GetTotalStat(StatType.Dexterity);
        
        if (player.Hands.Left == player.Hands.Right && player.Hands.Left != null)
            dexterity *= 1.2;

        damage = damage * (1.5*magic + luck + dexterity + intellect)*(0.8) + 2*luck; // 9
        
        int armor = player.GetTotalStat(StatType.Armor);
        
        int defense = armor + (int)(intellect + magic + luck);
        
        return ((int)Math.Max(1, damage), defense);
    }

    public (int damage, int defense) VisitNonWeapon(IEquippable weapon, Player player)
    {
        int damage = 0;
        double agility = player.GetTotalStat(StatType.Agility);
        double luck = 0;
        if(player.GetTotalStat(StatType.Luck) != 0)
        {
            luck = Random.Shared.Next() % player.GetTotalStat(StatType.Luck);
        }
        int armor = player.GetTotalStat(StatType.Armor);

        int defense = (int)(0.8*(armor * 0.5 + agility * 0.5 + luck));
        return (damage, defense);
    }
}