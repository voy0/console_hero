namespace console_hero;

public class Cell
{
   public bool IsWall { get; set; }
   public List<IItem> Items { get; } = new List<IItem>();
   public Cell(bool isWall = false)
   {
      IsWall = isWall;
   }
}