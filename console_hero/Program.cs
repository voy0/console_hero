using console_hero;

var mapGenerator = new PredefinedMapGenerator();
Map map = mapGenerator.GenerateMap();
var gameState =  new GameState(null, map); 
var gameRenderer = new ConsoleRenderer(gameState);
var inputHandler = new ConsoleInputHandler(gameState);


GameEngine gameEngine = new GameEngine(gameState, gameRenderer, inputHandler);
gameEngine.Run();
