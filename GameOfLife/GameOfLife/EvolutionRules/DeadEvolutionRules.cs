using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class DeadEvolutionRules : EvolutionRules
    {
        private readonly List<int> NeighbourRules = new List<int> {2, 3};

        public bool CellDies(List<Cell> livingCells, Cell cellTarget)
        {
            return !CellHasTwoOrThreeNeighbour(livingCells, cellTarget);
        }

        private bool CellHasTwoOrThreeNeighbour(List<Cell> livingCells, Cell cellTarget)
        {
            return NeighbourRules.Any(i => i == GetNumberOfNeighboursOfCell(livingCells, cellTarget));
        }
    }
}