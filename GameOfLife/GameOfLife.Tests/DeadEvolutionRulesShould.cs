using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public class DeadEvolutionRulesShould
    {
        [Fact]
        public void GetLiveCellsThatShouldDieWheTheyHaveLessThanTwoNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(5, 5);
            var cellOne = new Cell(0, 2);
            var cellTwo = new Cell(0, 1);
            grid.AddCell(cellOne);
            grid.AddCell(cellTwo);

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLiveNeighboursOfLivingCell(cellOne),
                grid.GetLiveNeighboursOfLivingCell(cellTwo)
            };

            var expectedDeadCells = new List<Cell> {cellOne, cellTwo};
            var cellsThatShouldDie =
                rules.GetLiveCellsThatShouldDie(neighboursOfAliveCell, new List<Cell> {cellOne, cellTwo});

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(2, cellsThatShouldDie.Count);
        }

        [Fact]
        public void GetLiveCellsThatShouldDieWheTheyHaveMoreThanThreeNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(5, 5);
            var cellOne = new Cell(0, 0);
            var cellTwo = new Cell(1, 1);
            var cellThree = new Cell(0, 1);
            var cellFour = new Cell(0, 2);
            var cellFive = new Cell(1, 2);
            grid.AddCell(cellOne);
            grid.AddCell(cellTwo);
            grid.AddCell(cellThree);
            grid.AddCell(cellFour);
            grid.AddCell(cellFive);

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLiveNeighboursOfLivingCell(cellOne),
                grid.GetLiveNeighboursOfLivingCell(cellTwo),
                grid.GetLiveNeighboursOfLivingCell(cellFour),
                grid.GetLiveNeighboursOfLivingCell(cellThree),
                grid.GetLiveNeighboursOfLivingCell(cellFive)
            };

            var expectedDeadCells = new List<Cell> {cellTwo, cellThree};
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(neighboursOfAliveCell,
                new List<Cell> {cellOne, cellTwo, cellThree, cellFour, cellFive});

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(2, cellsThatShouldDie.Count);
        }

        [Fact]
        public void GetLiveCellThatShouldDieWhenItHasNoNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(5, 5);
            var cellFour = new Cell(3, 3);
            grid.AddCell(cellFour);

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLiveNeighboursOfLivingCell(cellFour),
            };

            var expectedDeadCells = new List<Cell> {cellFour};
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(neighboursOfAliveCell, new List<Cell> {cellFour});

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(1, cellsThatShouldDie.Count);
        }

        [Fact]
        public void GetAllLiveCellsThatShouldDieWhenTheyHaveNoNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(5, 5);
            var cellOne = new Cell(3, 3);
            var cellTwo = new Cell(0, 0);
            grid.AddCell(cellOne);
            grid.AddCell(cellTwo);

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLiveNeighboursOfLivingCell(cellOne),
                grid.GetLiveNeighboursOfLivingCell(cellTwo)
            };

            var expectedDeadCells = new List<Cell> {cellOne , cellTwo};
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(neighboursOfAliveCell, new List<Cell> {cellOne, cellTwo});

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(2, cellsThatShouldDie.Count);
        }

        [Fact]
        public void GetNoLiveCellThatShouldDieWheTheyHaveTwoOrThreeNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(4, 4);
            var cellOne = new Cell(0, 0);
            var cellTwo = new Cell(0, 1);
            var cellThree = new Cell(1, 1);
            var cellFour = new Cell(1, 2);
            grid.AddCell(cellOne);
            grid.AddCell(cellTwo);
            grid.AddCell(cellThree);
            grid.AddCell(cellFour);

            var neighboursOfAliveCell = new List<IEnumerable<Cell>>
            {
                grid.GetLiveNeighboursOfLivingCell(cellOne),
                grid.GetLiveNeighboursOfLivingCell(cellTwo),
                grid.GetLiveNeighboursOfLivingCell(cellThree),
                grid.GetLiveNeighboursOfLivingCell(cellFour)
            };

            var expectedDeadCells = new List<Cell>();
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(neighboursOfAliveCell,
                new List<Cell> {cellOne, cellTwo, cellThree, cellFour});

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(0, cellsThatShouldDie.Count);
        }
    }
}