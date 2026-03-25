namespace console_hero;

public class InstructionsRenderer(List<string> instructions) : IModuleRenderer
{
    public int Height { get; set; } = instructions.Count;
    public void Render(){}

    public string GetLine(int y)
    {
        if (y < Height)
        {
            return instructions[y];
        }

        return "";
    }
}