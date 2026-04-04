using System.Collections.Generic;
// Pamiętaj o usingu do Twojego Enuma, np. using console_hero.Models;

namespace console_hero;

public class PlayerStatusRenderer(Player player) : IRenderer // (Albo IModuleRenderer, zależy jak to masz wpięte)
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

        _statusLines.Add($" {"Armor:", Lbl} {player.GetTotalStat(StatType.Armor), Val}");
        _statusLines.Add($" {"Strength:", Lbl} {player.GetTotalStat(StatType.Strength), Val}");
        _statusLines.Add($" {"Agility:", Lbl} {player.GetTotalStat(StatType.Agility), Val}");
        _statusLines.Add($" {"Dexterity:", Lbl} {player.GetTotalStat(StatType.Dexterity), Val}");

        _statusLines.Add("---------- M E N T A L ----------");

        _statusLines.Add($" {"Intellect:", Lbl} {player.GetTotalStat(StatType.Intellect), Val}");
        _statusLines.Add($" {"Luck:", Lbl} {player.GetTotalStat(StatType.Luck), Val}");
        _statusLines.Add($" {"Magic:", Lbl} {player.GetTotalStat(StatType.Magic), Val}");

        _statusLines.Add("======== E Q U I P P E D ========");
        
        if (player.Hands.Right == player.Hands.Left && player.Hands.Left != null)
        {
            _statusLines.Add($" {"Both Hands:", Lbl} {player.Hands.Left.ColoredName}"); 
        }
        else
        { 
            string leftHand = player.Hands.Left?.ColoredName ?? "(Empty)";
            string rightHand = player.Hands.Right?.ColoredName ?? "(Empty)";
            
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