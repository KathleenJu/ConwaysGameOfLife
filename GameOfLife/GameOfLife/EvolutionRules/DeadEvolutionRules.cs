using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class DeadEvolutionRules : EvolutionRules
    {
        private readonly List<int> NumberOfNeighboursNeededtoLive = new List<int> {2, 3};

        public bool CellDies(List<Cell> livingCells, Cell cellTarget)
        {
            return !CellHasTwoOrThreeNeighbours(livingCells, cellTarget);
        }

        private bool CellHasTwoOrThreeNeighbours(List<Cell> livingCells, Cell cellTarget)
        {
            return NumberOfNeighboursNeededtoLive.Any(i => i == GetNumberOfNeighboursOfCell(livingCells, cellTarget));
        }
    }
}