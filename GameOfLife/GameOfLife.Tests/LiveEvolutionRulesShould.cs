using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Xunit;

namespace GameOfLife.Tests
{
    public class LiveEvolutionRulesShould
    {
        [Fact]
        public void GetTheDeadCellThatShouldBecomeAliveWhenItHasThreeLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var grid = new Grid(5, 5);
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(1, 0));

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetDeadNeighboursOfLivingCell(new Cell(0, 2)),
                grid.GetDeadNeighboursOfLivingCell(new Cell(0, 1)),
                grid.GetDeadNeighboursOfLivingCell(new Cell(1, 0))
            };

            var expectedLiveCells = new List<Cell> {new Cell(1, 1)};
            var cellsThatShouldLive = rules.GetDeadCellsThatShouldLive(neighboursOfAliveCell);

            expectedLiveCells.Should().BeEquivalentTo(cellsThatShouldLive);
            Assert.Equal(1, cellsThatShouldLive.Count);
        }
        
        [Fact]
        public void GetMultipleDeadCellsThatShouldBecomeAliveWhenTheyHaveThreeLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var grid = new Grid(5, 5);
            grid.AddCell(new Cell(1, 1));
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(2, 1));
            grid.AddCell(new Cell(2, 0));

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetDeadNeighboursOfLivingCell(new Cell(1, 1)),
                grid.GetDeadNeighboursOfLivingCell(new Cell(1, 2)),
                grid.GetDeadNeighboursOfLivingCell(new Cell(2, 0)),
                grid.GetDeadNeighboursOfLivingCell(new Cell(2, 1))
            };

            var expectedLiveCells = new List<Cell> {new Cell(1, 0), new Cell(2, 2)};
            var cellsThatShouldLive = rules.GetDeadCellsThatShouldLive(neighboursOfAliveCell);

            expectedLiveCells.Should().BeEquivalentTo(cellsThatShouldLive);
            Assert.Equal(2, cellsThatShouldLive.Count);
        }
        
        [Fact]
            public void GetNoDeadCellsThatShouldBecomeAliveWhenTheyDoNotHaveThreeLiveNeighbours()
        {
            var rules = new LiveEvolutionRules();
            var grid = new Grid(5, 5);
            grid.AddCell(new Cell(1, 1));
            grid.AddCell(new Cell(1, 3));
            grid.AddCell(new Cell(2, 0));

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetDeadNeighboursOfLivingCell(new Cell(1, 1)),
                grid.GetDeadNeighboursOfLivingCell(new Cell(1, 3)),
                grid.GetDeadNeighboursOfLivingCell(new Cell(2, 0))
            };

            var expectedLiveCells = new List<Cell> {};
            var cellsThatShouldLive = rules.GetDeadCellsThatShouldLive(neighboursOfAliveCell);

            expectedLiveCells.Should().BeEquivalentTo(cellsThatShouldLive);
            Assert.Equal(0, cellsThatShouldLive.Count);
        }
    }
}