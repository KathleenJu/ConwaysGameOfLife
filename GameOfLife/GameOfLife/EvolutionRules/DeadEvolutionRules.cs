using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class DeadEvolutionRules
    {
        private readonly List<int> NumbersOfNeighboursNeededtoLive = new List<int> {2, 3};

        public List<Cell> GetLiveCellsThatShouldDie(List<IEnumerable<Cell>> listOfAllLiveNeighboursOfLiveCells, IEnumerable<Cell> livingCells)
        {
            var neighboursCount = GetAllNeighboursCount(listOfAllLiveNeighboursOfLiveCells);

            var cellsWithNoTwoOrThreeNeighbours = GetCellsWithNoTwoOrThreeNeighbours(neighboursCount);
            var livingCellsWithNoNeighbour = GetLivingCellsWithNoNeighbour(livingCells, neighboursCount);
            
            return cellsWithNoTwoOrThreeNeighbours.Concat(livingCellsWithNoNeighbour).ToList();
        }

        private List<Cell> GetCellsWithNoTwoOrThreeNeighbours(Dictionary<Cell, int> neighboursCount)
        {
            var cellsWithNoTwoOrThreeNeighbours = neighboursCount.Where(cellInDict =>!NumbersOfNeighboursNeededtoLive.Any(numberOfNeighbours => cellInDict.Value.Equals(numberOfNeighbours)))
                .Select(cell => cell.Key).ToList();
            return cellsWithNoTwoOrThreeNeighbours;
        }

        private static IEnumerable<Cell> GetLivingCellsWithNoNeighbour(IEnumerable<Cell> livingCells, Dictionary<Cell, int> dict)
        {
            var livingCellsWithNoNeighbour = livingCells.Where(x => !dict.Any(y => y.Key.Equals(x))).Select(x => x);
            return livingCellsWithNoNeighbour;
        }

        private static Dictionary<Cell, int> GetAllNeighboursCount(List<IEnumerable<Cell>> listOfAllLiveNeighboursOfLiveCells)
        {
            var neighboursCount = new Dictionary<Cell, int>();
            foreach (var liveNeighboursOfLivingCell in listOfAllLiveNeighboursOfLiveCells)
            {
                foreach (var cell in liveNeighboursOfLivingCell)
                {
                    var key = neighboursCount
                        .Where(cellInDict => cellInDict.Key.Row == cell.Row && cellInDict.Key.Column == cell.Column)
                        .Select(x => x.Key);
                    if (!key.Any())
                    {
                        neighboursCount.Add(cell, 1);
                    }
                    else
                    {
                        neighboursCount[key.First()]++;
                    }
                }
            }

            return neighboursCount;
        }
    }
}