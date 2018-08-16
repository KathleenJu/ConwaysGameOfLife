using System.Collections;
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
            if (!LivingCells.Any(c => c.Equals(cell)))
            {
                LivingCells.Add(cell);
            }
        }

        public void RemoveCell(Cell cell)
        {
            LivingCells.Remove(cell);
        }

        public IEnumerable<Cell> GetLiveNeighboursOfLivingCell(Cell cellTarget)
        {
            var allNeighbourOfCell = GetAllNeighboursOfLivingCell(cellTarget);
            var allLivingNeighboursOfCell = allNeighbourOfCell.Where(neighbourCell => LivingCells.Any(livingCell => livingCell.Equals(neighbourCell)));
            return allLivingNeighboursOfCell;
        }
        
        public IEnumerable<Cell> GetDeadNeighboursOfLivingCell(Cell cellTarget)
        {
            var allNeighbourOfCell = GetAllNeighboursOfLivingCell(cellTarget);
            var allDeadNeighboursOfCell = allNeighbourOfCell.Where(neighbourCell => !LivingCells.Any(livingCell => livingCell.Equals(neighbourCell)));
            return allDeadNeighboursOfCell;
        }

        public IEnumerable<Cell> GetAllNeighboursOfLivingCell(Cell cellTarget)
        {
            var neighbourCells = new List<Cell>();
            for (var row = cellTarget.Row - 1; row <= cellTarget.Row + 1; row++)
            {
                var actualRow = row < 0 ? Height - 1 : row;
                actualRow = row > Height - 1 ? 0 : actualRow;
                for (var col = cellTarget.Column - 1; col <= cellTarget.Column + 1; col++)
                {
                    var actualCol = col < 0 ? Width - 1 : col;
                    actualCol = col > Width - 1 ? 0 : actualCol;
                    neighbourCells.Add(new Cell(actualRow, actualCol));
                }
            }
                    
            return neighbourCells.Where(cell => !cell.Equals(cellTarget));
        }
    }
}