using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class LiveEvolutionRules : EvolutionRules
    {
        private readonly List<int> NumberOfNeighboursNeededtoLive = new List<int> {3};

        public bool CellLives(List<Cell> livingCells, Cell cellTarget)
        {
            return CellHasExactlyThreeLiveNeighbours(livingCells, cellTarget);
        }

        private bool CellHasExactlyThreeLiveNeighbours(List<Cell> livingCells, Cell cellTarget)
        {
            return NumberOfNeighboursNeededtoLive.Any(i => i == GetNumberOfNeighboursOfCell(livingCells, cellTarget));
        }
    }
}