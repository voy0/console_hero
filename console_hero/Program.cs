using console_hero;
using console_hero.Rendering;
Console.Clear();
var levelGenerator = new LevelGenerator();
Level level = levelGenerator.Generate();
var gameState =  new GameState(null, level); 
var gameRenderer = new ConsoleRenderer(gameState);
var inputHandler = new ConsoleInputHandler(gameState);


GameEngine gameEngine = new GameEngine(gameState, gameRenderer, inputHandler);
gameEngine.Run();
