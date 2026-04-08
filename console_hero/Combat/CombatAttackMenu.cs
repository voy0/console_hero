namespace console_hero.Actions;

public enum AllAttacks
{
    Stealth,
    Power,
    Magic,
}
public class CombatAttackMenu(GameState gameState) : IMenu
{
    public int CurrentIndex { get; private set; } = 0;
    public bool InFocus { get; set; }
    public bool IsEnabled { get; set; } = gameState.Status == GameStatus.Combat;

    public List<AllAttacks> Attacks { get; set; } = Enum.GetValues<AllAttacks>().ToList();

        

    public void GoUp()
    {
        if (Attacks.Count == 0 || !InFocus) return;
        int newIndex = CurrentIndex - 1;
        CurrentIndex = (newIndex < 0) ? Attacks.Count - 1 : newIndex;
    }

    public void GoDown()
    {
        if (Attacks.Count == 0 || !InFocus) return;
        CurrentIndex = (CurrentIndex + 1) % Attacks.Count;
    }

    public void ValidateIndex()
    {
        if (Attacks.Count == 0)
        {
            CurrentIndex = 0;
            return;
        }
        if (CurrentIndex >= Attacks.Count)
        {
            CurrentIndex = Attacks.Count - 1;
        }
    }
}