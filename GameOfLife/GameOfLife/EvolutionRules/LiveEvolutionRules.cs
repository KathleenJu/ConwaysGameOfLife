using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace GameOfLife
{
    public class LiveEvolutionRules
    {
        private readonly List<int> NumberOfNeighboursNeededtoLive = new List<int> {3};

        public List<Cell> GetDeadCellsThatShouldLive(List<IEnumerable<Cell>> listOfAllNeighboursOfLivingCells)
        {
            var dict = new Dictionary<Cell, int>();
            foreach (var neighboursOfLivingCell in listOfAllNeighboursOfLivingCells)
            {
                foreach (var cell in neighboursOfLivingCell)
                {
                    var key = dict.Where(c => c.Key.Row == cell.Row && c.Key.Column == cell.Column)
                        .Select(x => x.Key);
                    if (!key.Any())
                    {
                        dict.Add(cell, 1);
                    }
                    else
                    {
                        dict[key.First()]++;
                    }
                }
            }

            var cellsWithThreeNeighbours = dict.Where(x => x.Value == 3);
            return cellsWithThreeNeighbours.Select(x => x.Key).ToList();
        }
    }
}