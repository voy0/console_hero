namespace console_hero;

public class Map
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public Cell[,] Cells { get; set; }
    public Map(int w = 41, int h = 21)
    {
        Width = w;
        Height = h;
        Cells = new Cell[w, h];
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                Cells[i, j] = new Cell();
            }
        }
    }
    
    public bool MoveEnemy(int x, int y, int nx, int ny)
    {
        if (Cells[x, y].Occupant == null) return false;
        if (!Cells[nx, ny].IsFree) return false;
        
        Cells[nx, ny].Occupant = Cells[x, y].Occupant;
        Cells[x, y].Occupant = null;
        Cells[nx, ny].Occupant.Position = (nx, ny);
        return true;
    }
}