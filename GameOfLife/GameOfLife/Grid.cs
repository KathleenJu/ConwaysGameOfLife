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

        public int GetNumberOfNeighboursOfCell(Cell cellTarget)
        {
            var neighbouringCells = LivingCells.Where(cell => cell != cellTarget).Where(cell =>
                cell.Row >= cellTarget.Row - 1 && cell.Row <= cellTarget.Row + 1 &&
                cell.Column >= cellTarget.Column - 1 && cell.Column <= cellTarget.Column + 1);
            
            return neighbouringCells.Count();
        }
    }
}