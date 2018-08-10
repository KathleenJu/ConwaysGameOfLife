using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class LiveEvolutionRules 
    {
        private readonly List<int> NumberOfNeighboursNeededtoLive = new List<int> {3};

        public bool CellLives(List<Cell> livingCells, Cell cellTarget, int numberOfNeighbours)
        {
            return NumberOfNeighboursNeededtoLive.Any(i => i == numberOfNeighbours);
        }
    }
}