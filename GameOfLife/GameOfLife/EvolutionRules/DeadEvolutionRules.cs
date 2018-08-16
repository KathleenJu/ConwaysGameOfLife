using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class DeadEvolutionRules
    {
        public List<Cell> GetLiveCellsThatShouldDie(List<Cell> livingCells)//pass in the 
        {
            var grid = new Grid(5, 5);
            foreach (var cell in livingCells)
            {
                grid.AddCell(cell);
            }

            var cellsThatShouldDie = new List<Cell>();
            foreach (var cell in livingCells)
            {
                var liveNeighboursCount = grid.GetLiveNeighboursOfLivingCell(cell).Count();
                if (liveNeighboursCount != 2 && liveNeighboursCount != 3)
                {
                    cellsThatShouldDie.Add(cell);
                }
            }

            return cellsThatShouldDie;
        }
    }
}