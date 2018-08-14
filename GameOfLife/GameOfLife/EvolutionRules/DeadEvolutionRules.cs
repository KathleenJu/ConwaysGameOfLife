using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class DeadEvolutionRules
    {
        private readonly List<int> NumberOfNeighboursNeededtoLive = new List<int> {2, 3};

        public bool CellDies(IEnumerable<Cell> neighbouringCells)
        {
            return !NumberOfNeighboursNeededtoLive.Any(i => i == neighbouringCells.Count());
        }
    }
}