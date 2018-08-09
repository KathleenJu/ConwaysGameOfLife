using System.Collections.Generic;

namespace GameOfLife
{
    public class Grid
    {
        public int GridHeight { get; }
        public int GridWidth { get; }
        private List<Cell> LivingCells;

        public Grid(int gridHeight, int gridWidth)
        {
            GridHeight = gridHeight;
            GridWidth = gridWidth;
            LivingCells = new List<Cell>();
        }
    }
}