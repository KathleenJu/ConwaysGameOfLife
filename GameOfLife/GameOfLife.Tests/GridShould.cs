using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    public class GridShould
    {
        [Fact]
        public void GetTheCorrectNumberOfNeighboursOfALivingCell()
        {
            var grid = new Grid(5,5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(0, 2));
            const int numberOfNeighbours = 3;
            var actualNumberOfNeighbours = grid.GetNumberOfLivingNeighboursOfCell(cellTarget);
            
            Assert.Equal(actualNumberOfNeighbours, numberOfNeighbours);

        }
        
        [Fact]
        public void GetTheCorrectNumberOfNeighboursOfALivingCellWithNoNeighbour()
        {
            var grid = new Grid(5,5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            const int numberOfNeighbours = 0;
            var actualNumberOfNeighbours = grid.GetNumberOfLivingNeighboursOfCell(cellTarget);
            
            Assert.Equal(actualNumberOfNeighbours, numberOfNeighbours);

        }
        
        [Fact]
        public void GetTheCorrectNumberOfNeighboursOfALivingCellWithSparseNeighbours()
        {
            var grid = new Grid(5,5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(4, 4));
            grid.AddCell(new Cell(4, 4));
            grid.AddCell(new Cell(0, 2));
            const int numberOfNeighbours = 2;
            var actualNumberOfNeighbours = grid.GetNumberOfLivingNeighboursOfCell(cellTarget);
            
            Assert.Equal(actualNumberOfNeighbours, numberOfNeighbours);
        }
        
        [Fact]
        public void GetTheCorrectNumberOfNeighboursOfALivingCellOnEdgeOfTheGrid()
        {
            var grid = new Grid(5,5);
            var cellTarget = new Cell(2, 4);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(2, 0));
            grid.AddCell(new Cell(2, 3));
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(3, 4));
            const int numberOfNeighbours = 4;
            var actualNumberOfNeighbours = grid.GetNumberOfLivingNeighboursOfCell(cellTarget);
            
            Assert.Equal(actualNumberOfNeighbours, numberOfNeighbours);

        }
        
        [Fact]
        public void GetTheCorrectNumberOfNeighboursOfALivingCellOnACorner()
        {
            var grid = new Grid(4,4);
            var cellTarget = new Cell(3, 0);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(2, 0));
            grid.AddCell(new Cell(2, 1));
            grid.AddCell(new Cell(3, 1));
            grid.AddCell(new Cell(0, 3));
            grid.AddCell(new Cell(2, 3));
            grid.AddCell(new Cell(3, 3));
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(1, 3));
            const int numberOfNeighbours = 8;
            var actualNumberOfNeighbours = grid.GetNumberOfLivingNeighboursOfCell(cellTarget);
            
            Assert.Equal(actualNumberOfNeighbours, numberOfNeighbours);

        }
    }
}