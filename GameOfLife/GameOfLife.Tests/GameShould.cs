using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameShould
    {
        [Fact]
        public void RemoveCellFromGridWhenAliveCellDies()
        {
            var grid = new Grid(5,5);
            var initialLivingCells = new List<Cell> {new Cell(1,1), new Cell(0,1)};
            var game = new Game(grid);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var newlivingCells = new List<Cell>();
                
            Assert.Equal(game.CurrentGrid.GetLivingCells(), newlivingCells);
        }
    }
}