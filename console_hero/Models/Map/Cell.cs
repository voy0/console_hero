namespace console_hero;

public class Cell
{
   public bool IsWall { get; set; }
   public Stack<IItem> Items { get; } = new Stack<IItem>();
   public Cell(bool isWall = false)
   {
      IsWall = isWall;
   }
}