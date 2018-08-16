using System.Collections.Generic;

namespace GameOfLife
{
    public interface IRenderer
    {
        List<Cell> GetInitialStateOfGrid();
        void RenderGrid();
        void RenderMessage();
    }
}