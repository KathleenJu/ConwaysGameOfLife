using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    public class LiveEvolutionRulesShould
    {
        
        [Fact]
        public void ChangeTheStateOfDeadCellToAliveWhenItHasThreeLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var livingCells = new List<Cell>{new Cell(0, 1), new Cell(1,0), new Cell(1,2)};
            var cellTarget = new Cell(1, 1);
            var numberOfNeighbours = 3;
            var isAlive = rules.CellLives(numberOfNeighbours);

            Assert.True(isAlive);
        }

        [Fact]
        public void NotChangeTheStateOfTheCellToAliveWhenItHasTwoLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var livingCells = new List<Cell>{new Cell(0, 1), new Cell(1,0)};
            var cellTarget = new Cell(1, 1);
            var numberOfNeighbours = 2;
            var isAlive = rules.CellLives(numberOfNeighbours);

            Assert.False(isAlive);
        }
        
        [Fact]
        public void NotChangeTheStateOfTheCellToAliveWhenItHasFourLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var livingCells = new List<Cell>{new Cell(0, 1), new Cell(1,0), new Cell(2, 1), new Cell(1,2)};
            var cellTarget = new Cell(1, 1);
            var numberOfNeighbours = 4;
            var isAlive = rules.CellLives(numberOfNeighbours);

            Assert.False(isAlive);
        }
    }
}