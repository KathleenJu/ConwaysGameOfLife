using System;


namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var game = new GameOfLife();
            var consoleRenderer = new ConsoleRenderer();
            var gameInstance = new GameEngine(game, consoleRenderer);
            
            gameInstance.StartGame(); 
        }
    }
}