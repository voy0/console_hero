    namespace console_hero;

    public class GameState
    {
        public readonly Player Player;
        public readonly Level Level;
        public readonly InventoryMenu InventoryMenu;
        public List<string> Prompts;

        public GameState(Player? player = null, Level? level = null)
        {
            Player = player ?? new Player();
            Level = level ?? new Level();
            InventoryMenu = new InventoryMenu(Player.Inventory);
            Prompts = new List<string>();
        }
        public bool IsRunning { get; private set; } = false;

        public void Run()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }