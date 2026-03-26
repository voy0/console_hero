namespace console_hero;

public class ConsoleInputHandler(GameState gameState) : IInputHandler
{
    Player _player = gameState.Player;
    Map _map =  gameState.Level.Map;
    InventoryMenu _inventoryMenu = gameState.InventoryMenu;
    private List<string> _prompts = gameState.Prompts;
    
    public void HandleInput() 
    {
        ConsoleKey key = Console.ReadKey(intercept: true).Key;
        KeyBindings keyBindings = new KeyBindings(gameState);

        ICommand command;
        if (keyBindings.KeyToAction.TryGetValue(key, out KeyActions action))
        {
            command = keyBindings.Actions[action].Command;
        }
        else
        {
            command = new DefaultActionCommand(gameState);
        }
        
     
        command.Execute();
    }
}