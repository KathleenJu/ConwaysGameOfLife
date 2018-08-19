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
            var renderer = new ConsoleRenderer();
            renderer.RenderMessage("Conway's Game of Life\n");
            renderer.RenderGrid(new Grid(30,30));
            var height = renderer.GetGridDimension("height");
            var width = renderer.GetGridDimension("width");
            game.SetGridSize(height, width);
            var initialCells = renderer.GetInitialStateOfGrid();
            game.SetInitialStateOfGrid(initialCells);
            renderer.RenderGrid(game.Grid);
            while (true)
            {
                game.Evolve();
                renderer.RenderGrid(game.Grid);
                Thread.Sleep(1000);
            }

            
        }
    }
}