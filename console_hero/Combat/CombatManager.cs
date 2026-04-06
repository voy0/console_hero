namespace console_hero.Actions;

public class CombatManager(GameState gameState)
{
    public Enemy Enemy { get; private set; } 
    
    public void Enter(Enemy enemy)
    {
        Enemy = enemy;
      
        gameState.Status = GameStatus.Combat;
        
        gameState.Prompts.Add("Wybierz atak: [1] Zwykły, [2] Skryty, [3] Magiczny");
    }

    public void ExecutePlayerTurn(ICombatVisitor chosenAttackVisitor)
    {
        // Tutaj wklejasz kod z wczorajszej wiadomości!
        // 1. Obliczasz obrażenia gracza (wywołujesz weapon.Accept(...))
        // 2. Odejmujesz HP wrogowi
        // 3. Odbierasz cios od wroga i odejmujesz HP graczowi
        // 4. Jeśli ktoś zginął -> wywołujesz EndFight()
    }

    public void Bail()
    {
    
        gameState.Status = GameStatus.Exploration; 
    }
}