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
            Renderer.RenderGrid(new Grid(30, 30));
         
            var height = Renderer.GetGridDimension("height");
            var width = Renderer.GetGridDimension("width");
            Game.SetGridSize(height, width);
            
            var initialCells = Renderer.GetInitialStateOfGrid();
            Game.SetInitialStateOfGrid(initialCells);
            Renderer.RenderGrid(Game.Grid);
            
            while (true)
            {
                Game.Evolve();
                Renderer.RenderGrid(Game.Grid);
                Thread.Sleep(1000);
            }
        }
    }
}