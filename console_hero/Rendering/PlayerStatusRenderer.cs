using System.Collections.Generic;

namespace console_hero;

public class PlayerStatusRenderer(Player player) : IRenderer
{
    private readonly List<string> _statusLines = new();
    
    private const int Lbl = -14; 
    private const int Val = 3;   
    
    public int Height => _statusLines.Count; 
    
    public void Render()
    {
        _statusLines.Clear();
        
        _statusLines.Add("============ H E R O ============");
        _statusLines.Add($" Gold: {player.Wealth.Gold,-6}  Coins: {player.Wealth.Coins}");
        _statusLines.Add("=================================");
        
        _statusLines.Add($" {"Health:", Lbl} {player.Stats.Health.Value, Val} / {player.Stats.Health.MaxValue, Val}");
        _statusLines.Add($" {"Mana:", Lbl} {player.Stats.Mana.Value, Val} / {player.Stats.Mana.MaxValue, Val}");
        _statusLines.Add($" {"Stamina:", Lbl} {player.Stats.Stamina.Value, Val} / {player.Stats.Stamina.MaxValue, Val}");

        _statusLines.Add("-------- P H Y S I C A L --------");

        _statusLines.Add($" {"Armor:", Lbl} {player.Stats.Armor.Value, Val}");
        _statusLines.Add($" {"Strength:", Lbl} {player.Stats.Strength.Value, Val}");
        _statusLines.Add($" {"Agility:", Lbl} {player.Stats.Agility.Value, Val}");
        _statusLines.Add($" {"Dexterity:", Lbl} {player.Stats.Dexterity.Value, Val}");
        
        
        _statusLines.Add("---------- M E N T A L ----------");

        _statusLines.Add($" {"Intellect:", Lbl} {player.Stats.Intellect.Value, Val}");
        _statusLines.Add($" {"Luck:", Lbl} {player.Stats.Luck.Value, Val}");
        _statusLines.Add($" {"Magic:", Lbl} {player.Stats.Magic.Value, Val}");

        _statusLines.Add("======== E Q U I P P E D ========");
        
        if (player.Hands.Right == player.Hands.Left && player.Hands.Left != null)
        {
            _statusLines.Add($" {"Both Hands:", Lbl} {player.Hands.Left.Name}");
        }
        else
        {
            string leftHand = player.Hands.Left?.Name ?? "(Empty)";
            string rightHand = player.Hands.Right?.Name ?? "(Empty)";
            
            _statusLines.Add($" {"Left Hand:", Lbl} {leftHand}");
            _statusLines.Add($" {"Right Hand:", Lbl} {rightHand}");
        }
    }

    public string GetLine(int y)
    {
        if (y < _statusLines.Count)
        {
            return "    " + _statusLines[y]; 
        }
        
        return ""; 
    }
}