using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace GameOfLife
{
    public class GameEngine
    {
        private readonly GameOfLife GameOfLife;
        private readonly IRenderer Renderer;

        public GameEngine(GameOfLife gameOfLife, IRenderer renderer)
        {
            GameOfLife = gameOfLife;
            Renderer = renderer;
        }

        public void StartGame()
        {
            Renderer.SetTitle("Conway's Game of Life"); 
            Renderer.RenderTitle();

            var height = Renderer.GetGridDimension("height");
            var width = Renderer.GetGridDimension("width");
            GameOfLife.SetGridSize(height, width);

            var initialCells = Renderer.GetInitialStateOfGrid();
            GameOfLife.SetInitialStateOfGrid(initialCells);
            
            var generation = 1;
            var numberOfLivingCells = GameOfLife.LivingCells.Count();
            while (numberOfLivingCells != 0)
            {
                Renderer.SetGenerationNumber(generation); 
                Renderer.SetNumberOfLivingCells(numberOfLivingCells);
                Renderer.SetGrid(GameOfLife.GetGrid());
                Renderer.RenderGrid();
                GameOfLife.Evolve();
                generation++;
                numberOfLivingCells = GameOfLife.LivingCells.Count();
                Thread.Sleep(500);
            }
        }
    }
}