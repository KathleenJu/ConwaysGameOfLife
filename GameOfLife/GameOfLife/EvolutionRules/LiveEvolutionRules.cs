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
            var examp = new List<List<Cell>>
            {
                 new List<Cell>{new Cell(1, 1), new Cell(0,1), new Cell(2,3)},
                 new List<Cell>{new Cell(1, 1), new Cell(3,1), new Cell(1,3)},
                 new List<Cell>{new Cell(1, 1), new Cell(0,1), new Cell(0,3)}
                
            };
            var commonItems = listOfAllNeighboursOfLivingCells.SelectMany(neighbourCells => neighbourCells).Distinct()
                .Where(cell => listOfAllNeighboursOfLivingCells.TrueForAll(neighbourCells => neighbourCells.Contains(cell))).ToList();
            var commonItems1 =
                     examp.SelectMany(list => list.Distinct())
                    .GroupBy(cell => cell)
                    .Select(group => new { Count = group.Count(), Item = group.Key })
            .Where(item => item.Count == 3).Select(group => group.Item).ToList();

            return commonItems;
        }
    }
}