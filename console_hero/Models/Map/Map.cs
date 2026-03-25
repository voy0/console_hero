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
}