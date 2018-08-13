using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameShould
    {
        [Fact]
        public void RemoveCellFromGridWhenALiveCellDies()
        {
            var grid = new Grid(5,5);
            var initialLivingCells = new List<Cell> {new Cell(1,1)};
            var game = new Game(grid);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var newlivingCells = new List<Cell>();
                
            Assert.Equal(game.CurrentGrid.GetLivingCells(), newlivingCells);
        }
        
        [Fact]
        public void RemoveCellsFromGridWhenMultipleLiveCellsDie()
        {
            var grid = new Grid(5,5);
            var cellTarget = new Cell(1,1);
            var initialLivingCells = new List<Cell> {cellTarget, new Cell(1,2), new Cell(4,2), new Cell(1,0)};
            var game = new Game(grid);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var newlivingCells = new List<Cell>{cellTarget};
                
            Assert.Equal(game.CurrentGrid.GetLivingCells(), newlivingCells);
        }
        
        [Fact]
        public void KeepCellFromGridWhenALiveCellLives()
        {
            var grid = new Grid(5,5);
            var cellTarget = new Cell(1,1);
            var initialLivingCells = new List<Cell> {cellTarget, new Cell(0,1), new Cell(2,1)};
            var game = new Game(grid);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var newLivingCells = new List<Cell>{cellTarget};
                
            Assert.Equal(game.CurrentGrid.GetLivingCells(), newLivingCells);
            Assert.True(game.CurrentGrid.GetLivingCells().Count == newLivingCells.Count);
        }
        
        [Fact]
        public void AddADeadCellToGridWhenCellLives()
        {
            var grid = new Grid(5,5);
            var cellTarget = new Cell(1,1);
            var initialLivingCells = new List<Cell> {new Cell(0,1), new Cell(0,2), new Cell(1,0)};
            var game = new Game(grid);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var newLivingCells = new List<Cell>{cellTarget, new Cell(0,1)};
                
            Assert.Equal(game.CurrentGrid.GetLivingCells(), newLivingCells);
            Assert.True(game.CurrentGrid.GetLivingCells().Count == newLivingCells.Count);
        }
        
        [Fact]
        public void KeepTheStateOfTheGridAsNoCellDies()
        {
            var grid = new Grid(5,5);
            var initialLivingCells = new List<Cell> { new Cell(0,1), new Cell(2,1), new Cell(1,0), new Cell(1,2)};
            var game = new Game(grid);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
                
            Assert.Equal(game.CurrentGrid.GetLivingCells(), initialLivingCells);
            Assert.True(game.CurrentGrid.GetLivingCells().Count == initialLivingCells.Count);
        }
    }
}