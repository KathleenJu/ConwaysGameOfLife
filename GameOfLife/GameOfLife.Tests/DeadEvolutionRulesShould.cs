using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    public class DeadEvolutionRulesShould
    {
        [Fact]
        public void KillALiveCellThatHasFewerThanTwoNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var cellTarget = new Cell(1, 1);
            var grid = new Grid(5,5);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0,1));
            var neighboursOfACell = grid.GetLivingNeighboursOfCell(cellTarget);
            var isKilled = rules.CellDies(neighboursOfACell);

            Assert.True(isKilled);
        }

        [Fact]
        public void NotKillALiveCellThatTwoNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var cellTarget = new Cell(1, 1);
            var grid = new Grid(5,5);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0,1));
            grid.AddCell(new Cell(1,0));
            var neighboursOfACell = grid.GetLivingNeighboursOfCell(cellTarget);
            var isKilled = rules.CellDies(neighboursOfACell);

            Assert.False(isKilled);
        }
        
        [Fact]
        public void KillALiveCellThatHasMoreThanThreeNeighbour()
        {
            var rules = new DeadEvolutionRules();
            var cellTarget = new Cell(1, 1);
            var grid = new Grid(5,5);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0,1));
            grid.AddCell(new Cell(0,2));
            grid.AddCell(new Cell(1,0));
            grid.AddCell(new Cell(1,2));
            var neighboursOfACell = grid.GetLivingNeighboursOfCell(cellTarget);
            var isKilled = rules.CellDies(neighboursOfACell);

            Assert.True(isKilled);
        }

        [Fact]
        public void NotKillALiveCellThatHasThreeNeighbour()
        {
            var rules = new DeadEvolutionRules();
            var cellTarget = new Cell(1, 1);
            var grid = new Grid(5,5);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0,1));
            grid.AddCell(new Cell(0,2));
            grid.AddCell(new Cell(1,0));
            var neighboursOfACell = grid.GetLivingNeighboursOfCell(cellTarget);
            var isKilled = rules.CellDies(neighboursOfACell);

            Assert.False(isKilled);
        }
    }
}