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
            var livingCells = new List<Cell>();
            var cellTarget = new Cell(1, 1);
            livingCells.Add(cellTarget);
            livingCells.Add(new Cell(0, 1));
            var numberOfNeighbours = 1;
            var isKilled = rules.CellDies(numberOfNeighbours);

            Assert.True(isKilled);
        }

        [Fact]
        public void NotKillALiveCellThatTwoNeighbours()
        {
            var rules = new DeadEvolutionRules();
            var livingCells = new List<Cell>();
            var cellTarget = new Cell(1, 1);
            livingCells.Add(cellTarget);
            livingCells.Add(new Cell(0, 1));
            livingCells.Add(new Cell(1, 0));
            var numberOfNeighbours = 2;
            var isKilled = rules.CellDies(numberOfNeighbours);

            Assert.False(isKilled);
        }
        
        [Fact]
        public void KillALiveCellThatHasMoreThanThreeNeighbour()
        {
            var rules = new DeadEvolutionRules();
            var livingCells = new List<Cell>();
            var cellTarget = new Cell(1, 1);
            livingCells.Add(cellTarget);
            livingCells.Add(new Cell(0, 1));
            livingCells.Add(new Cell(0, 2));
            livingCells.Add(new Cell(1, 0));
            livingCells.Add(new Cell(1, 2));
            var numberOfNeighbours = 4;
            var isKilled = rules.CellDies(numberOfNeighbours);

            Assert.True(isKilled);
        }

        [Fact]
        public void NotKillALiveCellThatHasThreeNeighbour()
        {
            var rules = new DeadEvolutionRules();
            var livingCells = new List<Cell>();
            var cellTarget = new Cell(1, 1);
            livingCells.Add(cellTarget);
            livingCells.Add(new Cell(0, 1));
            livingCells.Add(new Cell(1, 0));
            livingCells.Add(new Cell(0, 2));
            var numberOfNeighbours = 3;
            var isKilled = rules.CellDies(numberOfNeighbours);

            Assert.False(isKilled);
        }
    }
}