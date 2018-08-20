using System;
using System.IO;
using System.Threading;

namespace GameOfLife
{
    public class GameOfLifeRender
    {
        private readonly Game Game;
        private readonly IRenderer Renderer;

        public GameOfLifeRender(Game game, IRenderer renderer)
        {
            Game = game;
            Renderer = renderer;
        }

        public void StartGame()
        {
            Renderer.RenderMessage("Conway's Game of Life\n");
            Renderer.RenderGrid(new Grid(20, 20));

            var height = Renderer.GetGridDimension("height");
            var width = Renderer.GetGridDimension("width");
            Game.SetGridSize(height, width);

            var initialCells = Renderer.GetInitialStateOfGrid();
            Game.SetInitialStateOfGrid(initialCells);
            
            var generation = 1;
            var numberOfLivingCells = Game.Grid.GetLivingCells().Count;
            while (numberOfLivingCells != 0)
            {
                Renderer.RenderMessage("Generation: " + generation + " ");
                Renderer.RenderMessage("No. of Cells: " + numberOfLivingCells + "\n");
                Renderer.RenderGrid(Game.Grid);
                Game.Evolve();
                generation++;
                numberOfLivingCells = Game.Grid.GetLivingCells().Count;
                Thread.Sleep(500);
            }
        }
    }
}