    namespace console_hero;

    public class GameState
    {
        public readonly Player Player;
        public Level Level;
        public readonly InventoryMenu InventoryMenu;
        public List<string> Prompts;

        public GameState(Player? player = null, Level? level = null)
        {
            
            Player = player ?? new Player();
            InventoryMenu = new InventoryMenu(Player.Inventory);
            KeyBindings keyBindings = new KeyBindings(this);
            Level = level ?? new Level(keyBindings);
            Prompts = new List<string>();
        }
        public bool IsRunning { get; private set; } = false;

        public void Run()
        {
            var levelGenerator = new LevelGenerator(this);
            levelGenerator.Generate();
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }