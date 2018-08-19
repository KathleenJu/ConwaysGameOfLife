﻿using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace GameOfLife.Tests
{
    public class GameShould
    {
        [Fact]
        public void ReturnAnEmptyGridWhenAllALiveCellDies()
        {
            var initialLivingCells = new List<Cell> {new Cell(1,1), new Cell(1,0), new Cell(3,3)};
            var game = new Game();
            game.SetGridSize(5, 5);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var actuaLivingCells = game.Grid.GetLivingCells();

            actuaLivingCells.Should().BeEmpty();
            Assert.Equal(0, actuaLivingCells.Count);
        }
        
        [Fact]
        public void RemoveCellsFromGridWhenMultipleLiveCellsDieAndAddCellsThatShouldBecomeAlive()
        {
            var game = new Game();
            var initialLivingCells = new List<Cell> {new Cell(1,1), new Cell(1,2), new Cell(4,2), new Cell(1,0)};
            game.SetGridSize(5, 5);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var expectedLiveCells = new List<Cell> {new Cell(1, 1), new Cell(0,2), new Cell( 2,1)};
            var actuaLivingCells = game.Grid.GetLivingCells();

            actuaLivingCells.Should().BeEquivalentTo(expectedLiveCells);
            Assert.Equal(3, actuaLivingCells.Count);
        }
        
        [Fact]
        public void KeepTheStateOfTheGridAsNoCellDies()
        {
            var game = new Game();
            var initialLivingCells = new List<Cell> {new Cell(1,0), new Cell(1,1), new Cell(2,0), new Cell(2,1)};
            game.SetGridSize(5, 5);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var expectedLiveCells = new List<Cell> {new Cell(1,0), new Cell(1,1), new Cell(2,0), new Cell(2,1)};
            var actuaLivingCells = game.Grid.GetLivingCells();

            actuaLivingCells.Should().BeEquivalentTo(expectedLiveCells);
            Assert.Equal(4, actuaLivingCells.Count);
        }
        
        [Fact]
        public void AddADeadCellToGridWhenCellLives()
        {
            var initialLivingCells = new List<Cell> {new Cell(0,1), new Cell(0,2), new Cell(1,0)};
            var game = new Game();
            game.SetGridSize(5, 5);
            game.SetInitialStateOfGrid(initialLivingCells);
            game.Evolve();
            var expectedLiveCells = new List<Cell> {new Cell(0, 1) , new Cell(1,1)};
            var actuaLivingCells = game.Grid.GetLivingCells();

            actuaLivingCells.Should().BeEquivalentTo(expectedLiveCells);
            Assert.Equal(2, actuaLivingCells.Count);
        }
         
    }
}