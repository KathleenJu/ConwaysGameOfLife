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
            var grid = new Grid(5, 5);
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(1, 0));
            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
//                grid.GetAllNeighbourCellsOfCell(new Cell(0,2));
                grid.GetLivingNeighbourCellsOfCell(new Cell(0, 2)),
                grid.GetLivingNeighbourCellsOfCell(new Cell(0, 1)),
                grid.GetLivingNeighbourCellsOfCell(new Cell(1, 0))
            };
            var expectedOutput = new List<Cell> {new Cell(1, 1), new Cell(0, 1)};
            var cellsThatShouldLive = rules.GetCellsThatShouldLive(neighboursOfAliveCell);

            Assert.Equal(expectedOutput, cellsThatShouldLive);
        }

        [Fact]
        public void NotChangeTheStateOfTheCellToAliveWhenItOnlyHasTwoLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var grid = new Grid(5, 5);
            grid.AddCell(new Cell(1, 1));
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(1, 0));
            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLivingNeighbourCellsOfCell(new Cell(1, 1)),
                grid.GetLivingNeighbourCellsOfCell(new Cell(0, 1)),
                grid.GetLivingNeighbourCellsOfCell(new Cell(1, 0))
            };
            var cellsThatShouldLive = rules.GetCellsThatShouldLive(neighboursOfAliveCell);
            var expectedOutput = new List<Cell> {new Cell(1, 1)};

            Assert.Equal(expectedOutput, cellsThatShouldLive);
        }

        [Fact]
        public void NotChangeTheStateOfTheCellToAliveWhenItHasFourLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var cellTarget = new Cell(1, 1);
            var grid = new Grid(5, 5);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(1, 0));
            grid.AddCell(new Cell(2, 1));
            grid.AddCell(new Cell(1, 2));
            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLivingNeighbourCellsOfCell(new Cell(0, 1)),
                grid.GetLivingNeighbourCellsOfCell(new Cell(1, 0)),
                grid.GetLivingNeighbourCellsOfCell(new Cell(2, 1)),
                grid.GetLivingNeighbourCellsOfCell(new Cell(1, 2))
            };
            var cellsThatShouldLive = rules.GetCellsThatShouldLive(neighboursOfAliveCell);
            var expectedOutput = new List<Cell> {new Cell(0, 1), new Cell(0, 1), new Cell(2,1), new Cell(1,2)};

            Assert.Equal(expectedOutput, cellsThatShouldLive);
        }
    }
}