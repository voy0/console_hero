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

       
        double scaleConstant = 50.0; 
    
        int safeEnemyArmor = Math.Max(0, Enemy.Armor.Value);
        double enemyDamageReduction = scaleConstant / (scaleConstant + safeEnemyArmor);
    
        int damageToEnemy = (int)Math.Max(1, Math.Round(playerDamage * enemyDamageReduction));
    
        Enemy.Health.Decrease(damageToEnemy);
        _gameState.Prompts.Add($"You did {damageToEnemy} DMG");

        if (Enemy.Health.IsEmpty)
        {
            _gameState.Prompts.Add($"{Enemy.Name} dies");
            _gameState.Level.RemoveEnemy(Enemy);
            Bail();
            return;
        }

        int safePlayerDefense = Math.Max(0, playerDefense);
        double playerDamageReduction = scaleConstant / (scaleConstant + safePlayerDefense);
    
        int damageToPlayer = (int)Math.Max(1, Math.Round(Enemy.Damage.Value * playerDamageReduction));
    
        player.Stats.Health.Decrease(damageToPlayer);
        _gameState.Prompts.Add($"{Enemy.Name} hits you for {damageToPlayer} DMG");

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
        gameState.Status = GameStatus.Exploration; 
    }
}