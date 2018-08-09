using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class DeadEvolutionRules : EvolutionRules
    {
        public bool CellDies(List<Cell> livingCells, Cell cellTarget)
        {
            return HasFewerThanTwoLiveNeighbours(livingCells, cellTarget) || HasMoreThanThreeLiveNeighbours(livingCells , cellTarget);
        }

        private bool HasFewerThanTwoLiveNeighbours(List<Cell> livingCells, Cell cellTarget)
        {
            var numberOfNeighbour = 2;
            return GetNumberOfNeighboursOfCell(livingCells, cellTarget) < numberOfNeighbour;
        }
        
        private bool HasMoreThanThreeLiveNeighbours(List<Cell> livingCells, Cell cellTarget)
        {
            var numberOfNeighbour = 3;
            return GetNumberOfNeighboursOfCell(livingCells, cellTarget) > numberOfNeighbour;
        }
    }
}