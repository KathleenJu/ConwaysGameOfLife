using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameShould
    {
        [Fact]
        public void ReturnAnEmptyGridWhenAllALiveCellDies()
        {
            var grid = new Grid(5,5);
            var initialLivingCells = new List<Cell> {new Cell(1,1), new Cell(1,0)};
            var game = new Game(grid);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var actuaLivingCells = game.Grid.GetLivingCells();

            actuaLivingCells.Should().BeEmpty();
            Assert.Equal(0, actuaLivingCells.Count);
        }
        
        [Fact]
        public void RemoveCellsFromGridWhenMultipleLiveCellsDie()
        {
            var grid = new Grid(5,5);
            var game = new Game(grid);
            var initialLivingCells = new List<Cell> {new Cell(1,1), new Cell(1,2), new Cell(4,2), new Cell(1,0)};
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var expectedLiveCells = new List<Cell> {new Cell(1, 1)};
            var actuaLivingCells = game.Grid.GetLivingCells();

            actuaLivingCells.Should().BeEquivalentTo(expectedLiveCells);
            Assert.Equal(1, actuaLivingCells.Count);
        }
        
        [Fact]
        public void KeepCellFromGridWhenALiveCellLives()
        {
            var grid = new Grid(5,5);
            var game = new Game(grid);
            var initialLivingCells = new List<Cell> {new Cell(1,1), new Cell(0,1), new Cell(2,1)};
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var expectedLiveCells = new List<Cell> {new Cell(1, 1)};
            var actuaLivingCells = game.Grid.GetLivingCells();

            actuaLivingCells.Should().BeEquivalentTo(expectedLiveCells);
            Assert.Equal(1, actuaLivingCells.Count);
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
            var expectedLiveCells = new List<Cell> {new Cell(0, 1) };
            var actuaLivingCells = game.Grid.GetLivingCells();

            actuaLivingCells.Should().BeEquivalentTo(expectedLiveCells);
            Assert.Equal(1, actuaLivingCells.Count);
        }
        
        [Fact]
        public void KeepTheStateOfTheGridAsNoCellDies()
        {
            var grid = new Grid(5,5);
            var initialLivingCells = new List<Cell> { new Cell(0,1), new Cell(2,1), new Cell(1,0), new Cell(1,2)};
            var game = new Game(grid);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
                
            Assert.Equal(game.Grid.GetLivingCells(), initialLivingCells);
            Assert.True(game.Grid.GetLivingCells().Count == initialLivingCells.Count);
        }
    }
}