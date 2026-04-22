using System.Collections.Generic;

namespace console_hero.Rendering;

public class LogRenderer : IModuleRenderer
{
    private List<string> _logs = new List<string>();
    public int Height { get; set; }
    
    public int MaxWidth { get; set; } = 45; 

    public void Render()
    {
        _logs = GameLogger.Instance.GetRecentLogs(5);
        Height = _logs.Count > 0 ? _logs.Count + 1 : 0; 
    }

    public string GetLine(int y)
    {
        if (y == 0) return "    --- LATEST LOGS ---";
        
        if (y > 0 && y <= _logs.Count)
        {
            string text = _logs[y - 1];
            
            if (text.Length > MaxWidth && MaxWidth > 5)
            {
                text = text.Substring(0, MaxWidth - 5) + "[...]";
            }
            
            return "    " + text;
        }
        return "";
    }
}