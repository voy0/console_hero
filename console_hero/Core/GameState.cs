    namespace console_hero;

    public class GameState(Player? player = null, Map? map = null)
    {
        public readonly Player Player = player ?? new Player();
        public readonly Map Map = map ?? new Map();
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