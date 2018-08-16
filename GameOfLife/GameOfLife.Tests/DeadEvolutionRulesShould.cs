using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public class DeadEvolutionRulesShould
    {
        [Fact]
        public void GetTheLiveCellThatShouldDieWhenItHasLessThanTwoNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(5, 5);
            var cellOne = new Cell(0, 0);
            var cellTwo = new Cell(1, 1);
            grid.AddCell(cellOne);
            grid.AddCell(cellTwo);

            var livingCells = grid.GetLivingCells();

            var expectedDeadCells = new List<Cell> {cellOne, cellTwo};
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(livingCells);

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(2, cellsThatShouldDie.Count);
        }

        [Fact]
        public void GetMultipleLiveCellsThatShouldDieWheTheyHaveLessThanTwoNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(5, 5);
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(1, 0));

            var livingCells = grid.GetLivingCells();

            var expectedDeadCells = new List<Cell> {new Cell(0, 2), new Cell(1, 0)};
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(livingCells);

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(2, cellsThatShouldDie.Count);
        }

        [Fact]
        public void GetLiveCellsThatShouldDieWhenTheCellsDontHaveNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(5, 5);
            var cellOne = new Cell(1, 1);
            grid.AddCell(cellOne);

            var livingCells = grid.GetLivingCells();

            var expectedDeadCells = new List<Cell> { cellOne };
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(livingCells);

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(1, cellsThatShouldDie.Count);
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
            
            var livingCells = grid.GetLivingCells();

            var expectedDeadCells = new List<Cell> {new Cell(1, 1), new Cell(0, 1)};
            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(livingCells);

            expectedDeadCells.Should().BeEquivalentTo(cellsThatShouldDie);
            Assert.Equal(2, cellsThatShouldDie.Count);
        }
        
        [Fact]
        public void GetNoLiveCellThatShouldDieWhenTheyHaveTwoOrThreeNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var grid = new Grid(4, 4);
            grid.AddCell(new Cell(1, 3));
            grid.AddCell(new Cell(1, 1));
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(2, 2));

            var livingCells = grid.GetLivingCells();

            var cellsThatShouldDie = rules.GetLiveCellsThatShouldDie(livingCells);

            cellsThatShouldDie.Should().BeEmpty();
            Assert.Equal(0, cellsThatShouldDie.Count);
        }
    }
}