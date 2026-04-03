namespace console_hero;

public class LevelInstructionsRenderer : IModuleRenderer
{
    private List<string> _instructions = new List<string>();
    public int Height { get; set; }
    public void Render(){}

    public LevelInstructionsRenderer(Level level, KeyBindings keyBindings)
    {
        foreach (var action in level.KeyActionsList)
        {
            var bindingInfo = keyBindings.Actions[action];
            
            _instructions.Add(Instructions.GetInstruction(action, keyBindings));
        }
        
        Height = _instructions.Count;
    }

    public string GetLine(int y)
    {
        if (y < Height)
        {
            return _instructions[y];
        }

        return "";
    }
}