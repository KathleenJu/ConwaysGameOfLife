using System.Collections.Generic;

namespace GameOfLife
{
    public interface IRenderer
    {
        void SetTitle(string title);
        void SetGenerationNumber(int generation);
        void SetNumberOfLivingCells(int noOflivingCells);
        void SetGrid(Grid grid);
        void RenderTitle();
        int GetGridDimension(string dimension);
        List<Cell> GetInitialStateOfGrid();
//        void RenderGridBorder(int height, int width);
        void RenderGrid();
    }
}