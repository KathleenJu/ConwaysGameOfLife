using System.Collections.Generic;

namespace GameOfLife
{
    public interface IRenderer
    {
        int GetGridDimension(string dimension);
        List<Cell> GetInitialStateOfGrid();
//        void RenderGridBorder(int height, int width);
        void RenderGrid(Grid grid);
        void RenderMessage(string message);
        
    }
}