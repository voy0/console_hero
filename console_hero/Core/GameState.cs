    namespace console_hero;

    public class GameState
    {
        public readonly Player Player;
        public readonly Map Map;
        public readonly InventoryMenu InventoryMenu;

        public GameState(Player? player = null, Map? map = null)
        {
            Player = player ?? new Player();
            Map = map ?? new Map();
            InventoryMenu = new InventoryMenu(Player.Inventory);
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