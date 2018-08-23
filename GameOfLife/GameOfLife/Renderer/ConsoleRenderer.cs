using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class ConsoleRenderer : IRenderer
    {
        private string Title;
        private int Generation;
        private int NumberOfLivingCells;
        private string GridString;
        
        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetGenerationNumber(int generation)
        {
            Generation = generation;
        }

        public void SetNumberOfLivingCells(int noOflivingCells)
        {
            NumberOfLivingCells = noOflivingCells;
        }

        public void SetGrid(Grid grid)
        {
            string gridString = "";
            for (var row = 0; row < grid.Height; row++)
            {
                for (var col = 0; col < grid.Width; col++)
                {
                    gridString += grid.GetLivingCells().Any(cell => cell.Row == row && cell.Column == col) ? "* " : "- ";
                }

                gridString += Environment.NewLine;
            }

            gridString += Environment.NewLine;
            GridString = gridString;
        }

        public void RenderTitle()
        {
            Console.WriteLine(Title);
        } 

        public int GetGridDimension(string dimension)
        {
            Console.Write("Please type in the " + dimension + " of the grid: ");
            var input = Console.ReadLine();
            int dimensionSize;
            while (!int.TryParse(input, out dimensionSize))
            {
                Console.Write("Please type in a NUMBER for the grid " + dimension + " : ");
                input = Console.ReadLine();
            }

            return dimensionSize;
        }

        public List<Cell> GetInitialStateOfGrid()
        {
            Console.Write("Type in a coordinates of your initial grid in this format - 1,2 3,2 1,3 : ");
            var input = Console.ReadLine();
            if (input == "")
            {
                return GetRandomInitialStateOfGrid();
            }

            while (!Regex.IsMatch(input, "^([0-9][0-9]*?,[0-9][0-9]*?( ?))+?$"))
            {
                Console.Write("Wrong format. Try again in x,y x,y format: ");
                input = Console.ReadLine();
            }

            var coordinates = input.Split(" ");
            return coordinates.Select(coord =>
            {
                var row = Int32.Parse(coord.Split(",").First()) - 1;
                var column = Int32.Parse(coord.Split(",").Last()) - 1;

                return new Cell(row, column);
            }).ToList();
        }

        private static List<Cell> GetRandomInitialStateOfGrid()
        {
            return new List<Cell>
            {
                new Cell(0, 0),
                new Cell(1, 1),
                new Cell(0, 2),
                new Cell(1, 2),
                new Cell(2, 1)
            };
        }

        public void RenderGrid()
        {
//            RenderBorder(grid);
            Console.WriteLine("\nGeneration: " + Generation + " No. of Cells: " + NumberOfLivingCells + "\n" + GridString );
        }

    }
}