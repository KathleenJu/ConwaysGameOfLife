using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class DeadEvolutionRules
    {
        private readonly List<int> NumbersOfNeighboursNeededtoLive = new List<int> {2, 3};

        public List<Cell> GetLiveCellsThatShouldDie(List<IEnumerable<Cell>> listOfAllLiveNeighboursOfLiveCells, IEnumerable<Cell> livingCells)
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

            var livingCellsWithNoNeighbour = GetLivingCellsWithNoNeighbour(livingCells, dict);
            var cellsWithNoTwoOrThreeNeighbours = dict.Where(cellInDict => !NumbersOfNeighboursNeededtoLive.Any(NumberOfNeighbours => cellInDict.Value.Equals(NumberOfNeighbours)));
            var cellsThatShouldDie = cellsWithNoTwoOrThreeNeighbours.Select(cellInDict => cellInDict.Key).ToList();
            cellsThatShouldDie.AddRange(livingCellsWithNoNeighbour);
            return cellsThatShouldDie;
        }

        private IEnumerable<Cell> GetLivingCellsWithNoNeighbour(IEnumerable<Cell> livingCells, Dictionary<Cell, int> dict)
        {
            var livingCellsWithNoNeighbour = livingCells.Where(x => !dict.Any(y => y.Key.Equals(x))).Select(x => x);
            return livingCellsWithNoNeighbour;
        }
    }
}