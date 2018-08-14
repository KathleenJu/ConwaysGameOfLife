using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GameOfLife
{
    public class LiveEvolutionRules 
    {
        private readonly List<int> NumberOfNeighboursNeededtoLive = new List<int> {3};

        public bool GetCellsThatShouldLive(IEnumerable<Cell> neighbouringCells, List<IEnumerable<Cell>> listOfAllNeighboursOfLivingCells)
        {
            return NumberOfNeighboursNeededtoLive.Any(i => i == neighbouringCells.Count());
        }

    }
}