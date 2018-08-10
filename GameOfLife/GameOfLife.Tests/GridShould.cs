using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    public class GridShould
    {
        [Fact]
        public void GetTheCorrectNumberOfNeighbourOfALivingCell()
        {
            var grid = new Grid(5,5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(0, 2));
            var numberOfNeighbours = 3;
            var actualNumberOfNeighbours = grid.GetNumberOfNeighboursOfCell(cellTarget);
            
            Assert.Equal(actualNumberOfNeighbours, numberOfNeighbours);

        }
        
        [Fact]
        public void GetTheCorrectNumberOfNeighbourOfALivingCellWithNoNeighbour()
        {
            var grid = new Grid(5,5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            var numberOfNeighbours = 0;
            var actualNumberOfNeighbours = grid.GetNumberOfNeighboursOfCell(cellTarget);
            
            Assert.Equal(actualNumberOfNeighbours, numberOfNeighbours);

        }
        
        [Fact]
        public void GetTheCorrectNumberOfNeighbourOfALivingCellWithSparseNeighbours()
        {
            var grid = new Grid(5,5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(5, 5));
            grid.AddCell(new Cell(4, 4));
            grid.AddCell(new Cell(0, 2));
            var numberOfNeighbours = 2;
            var actualNumberOfNeighbours = grid.GetNumberOfNeighboursOfCell(cellTarget);
            
            Assert.Equal(actualNumberOfNeighbours, numberOfNeighbours);

        }
    }
}