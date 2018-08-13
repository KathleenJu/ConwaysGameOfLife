using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        public int GridHeight { get; }
        public int GridWidth { get; }
        private readonly List<Cell> LivingCells;

        public Grid(int gridHeight, int gridWidth)
        {
            GridHeight = gridHeight;
            GridWidth = gridWidth;
            LivingCells = new List<Cell>();
        }

        public List<Cell> GetLivingCells()
        {
            return LivingCells;
        }

        public void AddCell(Cell cell)
        {
            LivingCells.Add(cell);
        }

        public void RemoveCell(Cell cell)
        {
            LivingCells.Remove(cell);
        }

        public int GetNumberOfLivingNeighboursOfCell(Cell cellTarget)
        {
            var neighbouringCells = GetLivingNeighbouringCellsofCell(cellTarget);

            return neighbouringCells.Count();
        }

        private IEnumerable<Cell> GetLivingNeighbouringCellsofCell(Cell cellTarget)
        {
            var topRow = cellTarget.Row == 0 ? GridHeight - 1 : cellTarget.Row - 1;
            var bottomRow = cellTarget.Row == GridHeight - 1 ? 0 : cellTarget.Row + 1;
            var leftColumn = cellTarget.Column == 0 ? GridWidth - 1 : cellTarget.Column - 1;
            var rightColumn = cellTarget.Column == GridWidth - 1 ? 0 : cellTarget.Column + 1;
            var neighbouringCells = LivingCells.Where(cell => cell != cellTarget).Where(cell => cell.Row == topRow || cell.Row == cellTarget.Row ||  cell.Row == bottomRow 
                                                              && cell.Column == leftColumn || cell.Column == cellTarget.Column || cell.Column == rightColumn);
            return neighbouringCells;
        }
    }
}