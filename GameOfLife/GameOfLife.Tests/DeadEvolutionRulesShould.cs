using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public class DeadEvolutionRulesShould
    {
        [Fact]
        public void GetTheLiveCellThatShouldDieWheItHasLessThanTwoNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(5, 5);
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(1, 1));
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(1, 2));

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLiveNeighboursOfLivingCell(new Cell(0, 0)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(1, 1)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(0, 2)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(1, 2))
            };

            var expectedDeadCells = new List<Cell> {new Cell(0, 0)};
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(neighboursOfAliveCell);

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(1, cellsThatShouldDie.Count);
        }

        [Fact]
        public void GetMultipleLiveCellsThatShouldDieWheTheyHaveLessThanTwoNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(5, 5);
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(1, 0));

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLiveNeighboursOfLivingCell(new Cell(0, 2)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(0, 1)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(1, 0))
            };

            var expectedDeadCells = new List<Cell> {new Cell(0, 2), new Cell(1, 0)};
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(neighboursOfAliveCell);

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(2, cellsThatShouldDie.Count);
        }

        [Fact]
        public void GetMultipleLiveCellsThatShouldDieWheTheyHaveMoreThanThreeNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(5, 5);
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(1, 1));
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(1, 2));

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLiveNeighboursOfLivingCell(new Cell(0, 0)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(1, 1)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(0, 2)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(0, 1)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(1, 2))
            };

            var expectedDeadCells = new List<Cell> {new Cell(1, 1), new Cell(0, 1)};
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(neighboursOfAliveCell);

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(2, cellsThatShouldDie.Count);
        }
        
        [Fact]
        public void GetNoLiveCellThatShouldDieWheTheyHaveTwoOrThreeNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(4, 4);
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(1, 3));
            grid.AddCell(new Cell(1, 1));
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(2, 2));

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLiveNeighboursOfLivingCell(new Cell(0, 0)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(1, 3)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(1, 1)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(1, 2)),
                grid.GetLiveNeighboursOfLivingCell(new Cell(2, 2))
            };

            var expectedDeadCells = new List<Cell> ();
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(neighboursOfAliveCell);

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(0, cellsThatShouldDie.Count);
        }
    }
}