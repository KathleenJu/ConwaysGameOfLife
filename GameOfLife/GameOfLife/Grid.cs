﻿using System.Collections;
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
            if (!LivingCells.Any(c => c.Row == cell.Row && c.Column == cell.Column))
            {
                LivingCells.Add(cell);
            }
        }

        public void RemoveCell(Cell cell)
        {
            LivingCells.Remove(cell);
        }

        public IEnumerable<Cell> GetLivingNeighboursOfCell(Cell cellTarget)
        {
            var allNeighbourOfCell = GetAllNeighboursOfCell(cellTarget);
            var allLivingNeighboursOfCell = allNeighbourOfCell.Where(neighbourCell => LivingCells.Any(livingCell => livingCell.Row == neighbourCell.Row && livingCell.Column == neighbourCell.Column));
            return allLivingNeighboursOfCell;
        }

        public IEnumerable<Cell> GetAllNeighboursOfCell(Cell cellTarget)
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
                    if (actualRow != cellTarget.Row || actualCol != cellTarget.Column)
                    {
                        var cell = new Cell(actualRow, actualCol);
                            neighbourCells.Add(cell);
                    }
                }
            }
            return neighbourCells;
        }
    }
}