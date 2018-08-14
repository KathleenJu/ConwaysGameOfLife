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
            var actualNeighbourCells = grid.GetLivingNeighbourCellsOfCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(3, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheCorrectNumberOfNeighboursOfALivingCellWithNoNeighbour()
        {
            var grid = new Grid(5, 5);
            var cellTarget = new Cell(1, 1);
            grid.AddCell(cellTarget);
            var expectedNeighbourCells = new List<Cell>();
            var actualNeighbourCells = grid.GetLivingNeighbourCellsOfCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(0, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheCorrectNumberOfNeighboursOfALivingCellWithSparseNeighbours()
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
            var actualNeighbourCells = grid.GetLivingNeighbourCellsOfCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(2, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheCorrectNumberOfNeighboursOfALivingCellOnEdgeOfTheGrid()
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
            var actualNeighbourCells = grid.GetLivingNeighbourCellsOfCell(cellTarget);

            expectedNeighbourCells.Should().BeEquivalentTo(actualNeighbourCells);
            Assert.Equal(3, actualNeighbourCells.Count());
        }

        [Fact]
        public void GetTheCorrectNumberOfNeighboursOfALivingCellOnACorner()
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
            var actualNeighbourCells = grid.GetLivingNeighbourCellsOfCell(cellTarget);

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
            const int numberOfLivingCells = 1;

            Assert.Equal(numberOfLivingCells, grid.GetLivingCells().Count);
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
            var actualNumberOfNeighbours = grid.GetAllNeighbourCellsOfCell(cellTarget);

            expectedOutput.Should().BeEquivalentTo(actualNumberOfNeighbours);
            Assert.True(actualNumberOfNeighbours.Count == 8);
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
            var actualNumberOfNeighbours = grid.GetAllNeighbourCellsOfCell(cellTarget);

            expectedOutput.Should().BeEquivalentTo(actualNumberOfNeighbours);
            Assert.Equal(8, actualNumberOfNeighbours.Count);
        }
    }
}