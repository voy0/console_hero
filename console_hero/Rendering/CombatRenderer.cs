using console_hero.Actions;

namespace console_hero.Rendering;

public class CombatRenderer(GameState gameState) : IModuleRenderer
{
    private CombatManager _manager = gameState.Combat;
    private List<string> _combatLines = new List<string>();
    public int Height { get; set; }
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
        for (int i = 0; i < _manager.Menu.Attacks.Count; i++)
        {
            string? arrow = null;
            if (_manager.Menu.CurrentIndex == i && _manager.Menu.InFocus)
            {
                arrow = $"{Ansi.BgWhite}{Ansi.FgRed}>";
            }
            _combatLines.Add($"{arrow} {i+1}. {_manager.Menu.Attacks[i].ToString()}{Ansi.Reset}");

        }
        Height = _combatLines.Count;
    }
}