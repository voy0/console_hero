    namespace console_hero;

    public class GameState
    {
        public readonly Player Player;
        public Level Level;
        public readonly InventoryMenu InventoryMenu;
        public List<string> Prompts;
        public KeyBindings KeyBindings{get; private set;}
        public bool IsRunning { get; private set; } = false;

        public GameState(Player? player = null)
        {
            Player = player ?? new Player();
            InventoryMenu = new InventoryMenu(Player.Inventory);
            Prompts = new List<string>();
            
            var levelGenerator = new LevelGenerator(this);
            Level = levelGenerator.Generate();
            KeyBindings = new KeyBindings(this);
        }
        
        public void Run()
        {
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }