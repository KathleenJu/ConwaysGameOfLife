using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    public class EvolutionRulesShould
    {
        [Fact]
        public void KillALiveCellThatHasFewerThanTwoNeighbours()
        {
            var rules = new EvolutionRules();
            var livingCells = new List<Cell>();
            var cellTarget = new Cell(1, 1);
            livingCells.Add(cellTarget);
            livingCells.Add(new Cell(0, 1));
            var isKilled = rules.HasFewerThanTwoLiveNeighbours(livingCells, cellTarget);

            Assert.True(isKilled);
        }

        [Fact]
        public void NotKillALiveCellThatTwoOrMoreNeighbour()
        {
            var rules = new EvolutionRules();
            var livingCells = new List<Cell>();
            var cellTarget = new Cell(1, 1);
            livingCells.Add(cellTarget);
            livingCells.Add(new Cell(0, 1));
            livingCells.Add(new Cell(1, 0));
            livingCells.Add(new Cell(0, 2));
            var isAlive = rules.HasFewerThanTwoLiveNeighbours(livingCells, cellTarget);

            Assert.True(isAlive);
        }
    }
}