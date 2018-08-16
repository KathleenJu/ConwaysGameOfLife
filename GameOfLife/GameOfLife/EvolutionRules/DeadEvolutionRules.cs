using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class DeadEvolutionRules
    {
        private readonly List<int> NumbersOfNeighboursNeededtoLive = new List<int> {2, 3};

        public List<Cell> GetLiveCellsThatShouldDie(List<IEnumerable<Cell>> listOfAllLiveNeighboursOfLiveCells)
        {
            var dict = new Dictionary<Cell, int>();
            foreach (var liveNeighboursOfLivingCell in listOfAllLiveNeighboursOfLiveCells)
            {
                foreach (var cell in liveNeighboursOfLivingCell)
                {
                    var key = dict
                        .Where(cellInDict => cellInDict.Key.Row == cell.Row && cellInDict.Key.Column == cell.Column)
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

            var cellsWithNoTwoOrThreeNeighbours = dict.Where(cellInDict => !NumbersOfNeighboursNeededtoLive.Any(NumberOfNeighbours => cellInDict.Value.Equals(NumberOfNeighbours)));
            return cellsWithNoTwoOrThreeNeighbours.Select(cellInDict => cellInDict.Key).ToList();
        }
    }
}