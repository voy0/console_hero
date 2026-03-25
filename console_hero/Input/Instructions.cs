namespace console_hero;

public static class Instructions
{
    public static string GetInstruction(KeyActions action)
    {
        var binding = KeyBindings.Actions[action];
        return $"Press {binding.Key} to {binding.Description}";
    }
}