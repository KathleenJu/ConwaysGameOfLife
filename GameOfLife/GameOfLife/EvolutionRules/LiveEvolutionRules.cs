using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GameOfLife
{
    public class LiveEvolutionRules 
    {
        private readonly List<int> NumberOfNeighboursNeededtoLive = new List<int> {3};

        public List<Cell> GetCellsThatShouldLive(List<IEnumerable<Cell>> listOfAllNeighboursOfLivingCells)
        {
            var foo = listOfAllNeighboursOfLivingCells.SelectMany(x => x).Distinct()
                .Where(w => listOfAllNeighboursOfLivingCells.TrueForAll(t => t.Contains(w))).ToList();
            return foo;
        }

    }
}