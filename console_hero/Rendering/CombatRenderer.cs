namespace console_hero.Rendering;

public class CombatRenderer(GameState gameState) : IModuleRenderer
{
    private List<string> _combatLines = new List<string>();
    public int Height { get; set; } = 2;
    public string GetLine(int y)
    {
        if(y < Height)
            return "    " + _combatLines[y];
        return "";
    }

    public void Render()
    {
        Enemy enemy = gameState.Combat.Enemy;
        _combatLines.Clear();
        _combatLines.Add($"{Ansi.FgRed}Fighting: {enemy.ColoredName}{Ansi.Reset}");
        _combatLines.Add($"{Ansi.FgRed}HP: {enemy.Health.Value}/{enemy.Health.MaxValue}  DMG: {enemy.Damage.Value} ARMOR: {enemy.Armor.Value}{Ansi.Reset}");
    }
}