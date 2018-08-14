using System.Collections.Generic;
using Moq;
using Xunit;

namespace GameOfLife.Tests
{
    public class LiveEvolutionRulesShould
    {
        
        [Fact]
        public void ChangeTheStateOfDeadCellToAliveWhenItHasThreeLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var grid = new Grid(5,5);
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(0,1));
            grid.AddCell(new Cell(1,0));
            var neighboursOfACell = grid.GetLivingNeighbouringCellsofCell(new Cell(0, 2));
            var cellsThatShouldLive = new List<Cell>{ new Cell(1,1), new Cell(0,1)};
            var isAlive = rules.GetCellsThatShouldLive(neighboursOfACell, It.IsAny<List<IEnumerable<Cell>>>());

            Assert.True(isAlive);
        }

        [Fact]
        public void NotChangeTheStateOfTheCellToAliveWhenItHasTwoLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var cellTarget = new Cell(1, 1);
            var grid = new Grid(5,5);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0,1));
            grid.AddCell(new Cell(1,0));
            var neighboursOfACell = grid.GetLivingNeighbouringCellsofCell(cellTarget);
            var isAlive = rules.GetCellsThatShouldLive(neighboursOfACell, It.IsAny<List<IEnumerable<Cell>>>());

            Assert.False(isAlive);
        }
        
        [Fact]
        public void NotChangeTheStateOfTheCellToAliveWhenItHasFourLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var cellTarget = new Cell(1, 1);
            var grid = new Grid(5,5);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0,1));
            grid.AddCell(new Cell(1,0));
            grid.AddCell(new Cell(2,1));
            grid.AddCell(new Cell(1,2));
            var neighboursOfACell = grid.GetLivingNeighbouringCellsofCell(cellTarget);
            var isAlive = rules.GetCellsThatShouldLive(neighboursOfACell, It.IsAny<List<IEnumerable<Cell>>>());

            Assert.False(isAlive);
        }
    }
}