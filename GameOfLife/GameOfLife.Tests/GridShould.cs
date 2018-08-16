using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public class GridShould
    {
        [Fact]
        public void GetTheLivingNeighboursOfALivingCell()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(0, 2));
            var expectedNeighbourCells = new List<Cell>
            {
                new Cell(0, 1),
                new Cell(0, 2),
                new Cell(1, 2)
            };
            var actualNeighbourCells = grid.GetLiveNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(3, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheLivingNeighboursOfASingleLivingCell()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            var expectedNeighbourCells = new List<Cell>();
            var actualNeighbourCells = grid.GetLiveNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(0, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheLivingNeighboursOfALivingCellWithSparseNeighbours()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(1, 2));
            grid.AddCell(new Cell(4, 4));
            grid.AddCell(new Cell(1, 3));
            grid.AddCell(new Cell(3, 1));
            grid.AddCell(new Cell(0, 2));
            var expectedNeighbourCells = new List<Cell>
            {
                new Cell(0, 2),
                new Cell(1, 2)
            };
            var actualNeighbourCells = grid.GetLiveNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(2, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheLivingNeighboursOfALivingCellOnEdgeOfTheGrid()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(2, 4);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(2, 0));
            grid.AddCell(new Cell(2, 3));
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(3, 4));
            var expectedNeighbourCells = new List<Cell>
            {
                new Cell(2, 0),
                new Cell(2, 3),
                new Cell(3, 4)
            };
            var actualNeighbourCells = grid.GetLiveNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(3, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheLivingNeighboursOfALivingCellOnACorner()
        {
            var grid = new Grid(4, 4);
            var cellTarget = new Cell(3, 0);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(2, 0));
            grid.AddCell(new Cell(3, 1));
            grid.AddCell(new Cell(0, 3));
            grid.AddCell(new Cell(2, 3));
            grid.AddCell(new Cell(3, 3));
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(1, 3));
            var expectedNeighbourCells = new List<Cell>
            {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(2, 0),
                new Cell(3, 1),
                new Cell(0, 3),
                new Cell(2, 3),
                new Cell(3, 3)
            };
            var actualNeighbourCells = grid.GetLiveNeighboursOfLivingCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(7, actualNeighbourCells.Count());
        }

        [Fact]
        public void NotAddCelIfAlreadyExist()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(1, 1));

            Assert.Equal(1, grid.GetLivingCells().Count);
        }

        [Fact]
        public void GetAllEightNeighbourOfCell()
        {
            var grid = new Grid(4, 4);
            var cellTarget = new Cell(1, 1);
            var expectedOutput = new List<Cell>
            {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(0, 2),
                new Cell(1, 0),
                new Cell(1, 2),
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(2, 2)
            };
            var actualNeighboursOfCell = grid.GetAllNeighboursOfLivingCell(cellTarget);

            expectedOutput.Should().BeEquivalentTo(actualNeighboursOfCell);
            Assert.Equal(8, actualNeighboursOfCell.Count());
        }

        [Fact]
        public void GetAllEightNeighbourOfCellInACorner()
        {
            var grid = new Grid(4, 4);
            var cellTarget = new Cell(3, 0);
            var expectedOutput = new List<Cell>
            {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(3, 1),
                new Cell(0, 3),
                new Cell(2, 3),
                new Cell(3, 3)
            };
            var actualNeighboursOfCell = grid.GetAllNeighboursOfLivingCell(cellTarget);

            expectedOutput.Should().BeEquivalentTo(actualNeighboursOfCell);
            Assert.Equal(8, actualNeighboursOfCell.Count());
        }
        
        [Fact]
        public void GetTheDeadNeighboursOfCellInACorner()
        {
            var grid = new Grid(4, 4);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(1, 0));
            
            var expectedDeadNeighbours = new List<Cell>
            {
                new Cell(0, 2),
                new Cell(1, 2),
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(2, 2)
            };
            var actualDeadNeighboursOfCell = grid.GetDeadNeighboursOfLivingCell(cellTarget);

            expectedDeadNeighbours.Should().BeEquivalentTo(actualDeadNeighboursOfCell);
            Assert.Equal(5, actualDeadNeighboursOfCell.Count());
        }
        
        
    }
}