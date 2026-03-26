namespace console_hero;

public static class Instructions
{
    public static string GetInstruction(KeyActions action, KeyBindings keyBindings)
    {
        var binding = keyBindings.Actions[action];
        return $"Press {binding.Key} to {binding.Description}";
    }
}