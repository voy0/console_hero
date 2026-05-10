namespace console_hero;

public class Cell
{
   public bool IsFree => !(IsWall || IsOccupied || HasPlayer);
   public bool HasPlayer { get; set; }
   public bool IsWall { get; set; }
   public Enemy? Occupant { get; set; }
   public bool IsOccupied => Occupant != null;
   private Stack<IItem> items { get; } = new Stack<IItem>();
   public Cell(bool isWall = false)
   {
      IsWall = isWall;
   }
   public int ItemsCount => items.Count; 
   public void PushItem(IItem item)
   {
      items.Push(item);
   }

   public IItem? PopItem()
   {
      if (IsOccupied || items.Count == 0) return null;
        
      return items.Pop();
   }
   public IItem? PeekItem()
   {
      if (IsOccupied || items.Count == 0) return null;
        
      return items.Peek();
   }
   
}