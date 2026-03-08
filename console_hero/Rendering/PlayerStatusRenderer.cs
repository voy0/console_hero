using System.Collections.Generic;

namespace console_hero;

public class PlayerStatusRenderer(Player player)
{
    // Zamieniamy StringBuilder na listę linijek
    private readonly List<string> _statusLines = new();
    
    public int Height => _statusLines.Count; // Przydatne, by wiedzieć jak wysoki jest panel
    
    public void Render()
    {
        _statusLines.Clear();
        _statusLines.Add("========== H E R O ==========");
        
        _statusLines.Add($"Health:\t{player.Stats.Health.Value} / {player.Stats.Health.MaxValue}");
        _statusLines.Add($"Mana:\t{player.Stats.Mana.Value} / {player.Stats.Mana.MaxValue}");
        _statusLines.Add($"Stamina:\t{player.Stats.Stamina.Value} / {player.Stats.Stamina.MaxValue}");

        _statusLines.Add("====== P H Y S I C A L ======");

        _statusLines.Add($"Agility:\t{player.Stats.Agility.Value}");
        _statusLines.Add($"Dexterity:\t{player.Stats.Dexterity.Value}");
        _statusLines.Add($"Strength:\t{player.Stats.Strength.Value}");
        
        _statusLines.Add("======== M E N T A L ========");

        _statusLines.Add($"Intelligence:\t{player.Stats.Intelligence.Value}");
        _statusLines.Add($"Luck:\t\t{player.Stats.Luck.Value}");
        _statusLines.Add($"Magic:\t\t{player.Stats.Magic.Value}");
        
        _statusLines.Add("====== E Q U I P P E D ======");
        _statusLines.Add($"Left Hand:\t{player.Hands.LeftHand}");
        _statusLines.Add($"Right Hand:\t{player.Hands.RightHand}");
                    
        _statusLines.Add("===== I N V E N T O R Y =====");
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