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

        public int GetNumberOfNeighboursOfCell(Cell cellTarget)
        {
            var actualNeighbourCells = GetAllNeighboursOfCell(cellTarget);
            var neighbouringCells = LivingCells.Where(cell => actualNeighbourCells.Contains(cell));
            
            return neighbouringCells.Count();
        }

        private List<Cell> GetAllNeighboursOfCell(Cell cellTarget)
        {
            var actualNeighbourCells = new List<Cell>();
            for (var row = cellTarget.Row - 1; row <= cellTarget.Row + 1; row++)
            {
                for (var column = cellTarget.Column - 1; column <= cellTarget.Column + 1; column++)
                {
                    row = row == 0 ? GridHeight - 1 : row;
                    row = row == GridHeight - 1 ? 0 : row;
                    column = column == 0 ? GridWidth - 1 : column;
                    column = column == GridWidth - 1 ? 0 : column;
                    actualNeighbourCells.Add(new Cell(row, column));
                }
            }

            return actualNeighbourCells;
        }
    }
}