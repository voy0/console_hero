using console_hero;
using console_hero.Rendering;
Console.Clear();
var gameState =  new GameState(null, null); 
var gameRenderer = new ConsoleRenderer(gameState);
var inputHandler = new ConsoleInputHandler(gameState);


GameEngine gameEngine = new GameEngine(gameState, gameRenderer, inputHandler);
gameEngine.Run();
