namespace console_hero.Rendering;

public class PromptRenderer(Player player, Map map, GameState gameState) : IModuleRenderer
{
    private List<string> _prompt = new List<string>();
    public int Height { get; set; } = 0;
    public void Render()
    {
        _prompt.Clear();
        int x = player.Position.x;
        int y = player.Position.y;
        foreach(var prompt in gameState.Prompts)
        {
            _prompt.Add(prompt);
        }
        gameState.Prompts.Clear();
        if (map.Cells[x, y].ItemsCount != 0) // TODO move detection responsiblity to detect
        {
            _prompt.Add($"Standing on: {map.Cells[x, y].PeekItem().ColoredName}");
            if(!player.Inventory.IsFull)
            {
                var keyaction = gameState.KeyBindings.Actions[KeyActions.PickupItem];
                _prompt.Add($"Press {keyaction.Key} to {keyaction.Description}");
            }
        }

        var i = gameState.InventoryMenu.CurrentIndex;
        if (!player.Inventory.IsEmpty)
        {
            var item = player.Inventory.Items[i];
            foreach (var action in item.AvailableActions)
            {
                var keyaction = gameState.KeyBindings.Actions[action];
                _prompt.Add($"Press {keyaction.Key} to {keyaction.Description}");
            }
        }

        if (player.Inventory.Items.Count >= 2)
        {
            var keyactionup = gameState.KeyBindings.Actions[KeyActions.SelectInventoryDown];
            var keyactiondown = gameState.KeyBindings.Actions[KeyActions.SelectInventoryUp];
            _prompt.Add($"Press {keyactionup.Key} to {keyactionup.Description}");
            _prompt.Add($"Press {keyactiondown.Key} to {keyactiondown.Description}");
            
        }
        
        Height = _prompt.Count;
    }

    public string GetLine(int y)
    {
        if (y < Height)
        {
            return "    " + _prompt[y];
        }

        return "";
    }
}