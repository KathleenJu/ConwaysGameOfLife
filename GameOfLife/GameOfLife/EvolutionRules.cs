using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class EvolutionRules
    {
        public bool HasFewerThanTwoLiveNeighbours(List<Cell> livingCells, Cell cellTarget)
        {
            var neighbouringCells = livingCells.Where(cell => cell != cellTarget).Where(cell =>
                cell.Row >= cellTarget.Row - 1 && cell.Row <= cellTarget.Row + 1 && cell.Column >= cellTarget.Column - 1 && cell.Column <= cellTarget.Column + 1);
            var foo = neighbouringCells.Count() < 2;

            return foo;
        }
    }
}