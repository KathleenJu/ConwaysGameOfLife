using System.Collections.Generic;
using FluentAssertions;
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
                grid.GetAllNeighboursOfLivingCell(new Cell(0, 2)),
                grid.GetAllNeighboursOfLivingCell(new Cell(0, 1)),
                grid.GetAllNeighboursOfLivingCell(new Cell(1, 0))
            };

            var expectedLiveCells = new List<Cell> {new Cell(1, 1)};
            var cellsThatShouldLive = rules.GetDeadCellsThatShouldLive(neighboursOfAliveCell);

            expectedLiveCells.Should().BeEquivalentTo(cellsThatShouldLive);
            Assert.Equal(1, cellsThatShouldLive.Count);
        }
    }
}