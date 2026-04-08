    using console_hero.Actions;

    namespace console_hero;

    public enum GameStatus
    {
        Exploration,
        Combat,
        GameOver
    }
    public class GameState
    {
        public readonly Player Player;
        public Level Level;
        public readonly InventoryMenu InventoryMenu;
        public List<string> Prompts;
        public KeyBindings KeyBindings{get; private set;}
        public bool IsRunning { get; private set; } = false;
        public GameStatus Status;
        public CombatManager Combat;
        public MenusManager Menus;

        public GameState(Player? player = null)
        {
            Player = player ?? new Player();
            Prompts = new List<string>();
            Menus = new MenusManager();
            
            InventoryMenu = new InventoryMenu(Player.Inventory);
            Menus.RegisterMenu(InventoryMenu);
            InventoryMenu.InFocus = true;
            
            
            Combat = new CombatManager(this, new CombatAttackMenu(this));
            Menus.RegisterMenu(Combat.Menu);
            
            
            var levelGenerator = new LevelGenerator(this);
            Level = levelGenerator.Generate();
            KeyBindings = new KeyBindings(this);
        }
        
        public void Run()
        {
            Status = GameStatus.Exploration;
            IsRunning = true;
        }

        public void Stop()
        {
            IsRunning = false;
        }
    }