using System;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var game = new Game();
            var consoleRenderer = new ConsoleRenderer();
            var gameOfLife = new GameOfLifeRender(game, consoleRenderer);
            
            gameOfLife.StartGame();
        }
    }
}