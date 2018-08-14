using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Grid
    {
        public int Height { get; }
        public int Width { get; }
        private readonly List<Cell> LivingCells;

        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
            LivingCells = new List<Cell>();
        }

        public List<Cell> GetLivingCells()
        {
            return LivingCells;
        }

        public void AddCell(Cell cell)
        {
            if (!LivingCells.Contains(cell))
            {
                LivingCells.Add(cell);
            }
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

        public IEnumerable<Cell> GetLivingNeighbouringCellsofCell(Cell cellTarget)
        {
            var topRow = cellTarget.Row == 0 ? Height - 1 : cellTarget.Row - 1;
            var bottomRow = cellTarget.Row == Height - 1 ? 0 : cellTarget.Row + 1;
            var leftColumn = cellTarget.Column == 0 ? Width - 1 : cellTarget.Column - 1;
            var rightColumn = cellTarget.Column == Width - 1 ? 0 : cellTarget.Column + 1;

            var neighbouringCells = LivingCells.Where(cell => cell != cellTarget).Where(cell =>
                cell.Row == topRow || cell.Row == cellTarget.Row || cell.Row == bottomRow
                && cell.Column == leftColumn || cell.Column == cellTarget.Column || cell.Column == rightColumn);
            return neighbouringCells;
        }
    }
}