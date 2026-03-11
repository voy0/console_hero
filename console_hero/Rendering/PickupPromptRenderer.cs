namespace console_hero;

public class PickupPromptRenderer(Player player, Map map) : IRenderable
{
    private string _prompt = "";
    public int Height => 1;
    public void Render()
    {
        int x = player.Position.x;
        int y = player.Position.y;
        if (map.Cells[x, y].Items.Count != 0)
        {
            _prompt = $"Standing on: {map.Cells[x, y].Items.Peek().Name}";
        }
        else
        {
            _prompt = "";
        }
    }

    public string GetLine(int y)
    {
        if (y < Height)
        {
            return "    " + _prompt;
        }

        return "";
    }
}