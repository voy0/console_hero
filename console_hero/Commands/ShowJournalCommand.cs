namespace console_hero;

public class ShowJournalCommand(GameState gameState) : ICommand
{
    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("==== J O U R N A L ====");
        
        foreach (var log in GameLogger.Instance.GetLogs())
        {
            Console.WriteLine(log);
        }

        Console.WriteLine("\n[Press any key to return...]");
        Console.ReadKey(true);

        gameState.ForceRedraw = true;
    }
}