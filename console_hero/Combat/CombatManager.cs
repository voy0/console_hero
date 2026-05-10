using console_hero.Events;

namespace console_hero.Actions;

public class CombatManager(GameState gameState, CombatAttackMenu menu)
{
    private GameState _gameState = gameState;
    public Enemy Enemy { get; private set; }
    public CombatAttackMenu Menu { get; private set; } = menu;
    public void Enter(Enemy enemy)
    {
        Enemy = enemy;
        Menu.IsEnabled = true;
        enemy.InFight = true;
        gameState.Status = GameStatus.Combat;
        gameState.Menus.ForceFocus(Menu);
    }
    public void ExecuteSelectedAttack()
    {
        AllAttacks selectedAttack = Menu.Attacks[Menu.CurrentIndex];

        ICombatVisitor visitor = selectedAttack switch
        {
            AllAttacks.Stealth => new StealthAttackVisitor(),
            AllAttacks.Power => new PowerAttackVisitor(),
            AllAttacks.Magic => new MagicAttackVisitor(),
            _ => new PowerAttackVisitor()
        };

        ExecutePlayerTurn(visitor);
    }
    public void ExecutePlayerTurn(ICombatVisitor chosenAttackVisitor)
    {
        Player player = _gameState.Player;
    
        IEquippable weapon = player.Hands.Right ?? new BareHands();

        var (playerDamage, playerDefense) = weapon.Accept(chosenAttackVisitor, player, weapon);

       
        double scaleVariable = Random.Shared.NextDouble()%15; 
    
        int safeEnemyArmor = Math.Max(0, Enemy.GetEffectiveArmor());
        double enemyDamageReduction = scaleVariable / (scaleVariable + safeEnemyArmor);
    
        int damageToEnemy = (int)Math.Max(1, Math.Round(playerDamage * enemyDamageReduction));
        damageToEnemy += Random.Shared.Next() % damageToEnemy/3;
        if (Random.Shared.Next(100) < 20)
        {
            damageToEnemy *= 3;
            _gameState.Prompts.Add($"You did {damageToEnemy} DMG (CRIT)");
            GameLogger.Instance.Log($"Did {damageToEnemy} DMG (CRIT) to {Enemy.Name}");
        }
        else
        {
            _gameState.Prompts.Add($"You did {damageToEnemy} DMG");
            GameLogger.Instance.Log($"Did {damageToEnemy} DMG to {Enemy.Name}");
        }
        
        Enemy.Health.Decrease(damageToEnemy);
        
        if (Enemy.Health.IsEmpty)
        {
            _gameState.Prompts.Add($"{Enemy.Name} dies");
            GameLogger.Instance.Log($"Slayed {Enemy.Name}");
            if (Enemy.GuildObject != null)
            {
                Enemy.GuildObject.Population--;
            }
            GameEventManager.Instance.Notify(new GameEvent(EventType.EnemyDied, Enemy.GuildType));
            Enemy.UnsubscribeFromEvents();
            _gameState.Level.RemoveEnemy(Enemy);
            Bail();
            return;
        }

        scaleVariable = Random.Shared.NextDouble()%10; 
        int safePlayerDefense = Math.Max(0, playerDefense);
        safePlayerDefense = Random.Shared.Next() % safePlayerDefense;
        double playerDamageReduction = scaleVariable / (scaleVariable + safePlayerDefense);
        
        double effectiveDamageToPlayer = Enemy.GetEffectiveDamage(); 
        int damageToPlayer = (int)Math.Max(1, Math.Round(effectiveDamageToPlayer * playerDamageReduction));
    
        player.Stats.Health.Decrease(damageToPlayer);
        _gameState.Prompts.Add($"{Enemy.Name} hits you for {damageToPlayer} DMG");
        GameLogger.Instance.Log($"{Enemy.Name} hit player for {damageToPlayer} DMG");
        

        if (player.Stats.Health.IsEmpty)
        {
            _gameState.Status = GameStatus.GameOver;
            _gameState.Stop();
        }
    }

    public void Bail()
    {
        menu.InFocus = false;
        menu.IsEnabled = false;
        Enemy.InFight = false; 
        gameState.Status = GameStatus.Exploration; 
    }
}