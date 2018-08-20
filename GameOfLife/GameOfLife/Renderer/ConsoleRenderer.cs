using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameOfLife
{
    public class ConsoleRenderer : IRenderer
    {
        public int GetGridDimension(string dimension)
        {
            RenderMessage("Please type in the " + dimension + " of the grid: ");
            var input = Console.ReadLine();
            int dimensionSize;
            while (!int.TryParse(input, out dimensionSize))
            {
                RenderMessage("Please type in a NUMBER for the grid " + dimension + " : ");
                input = Console.ReadLine();
            }

            return dimensionSize;
        }

        public List<Cell> GetInitialStateOfGrid()
        {
            RenderMessage("Type in a coordinates of your initial grid in this format - 1,2 3,2 1,3 : ");
            var input = Console.ReadLine();
            if (input == "")
            {
                return GetRandomInitialStateOfGrid();
            }

            while (!Regex.IsMatch(input, "^([0-9][0-9]*?,[0-9][0-9]*?( ?))+?$"))
            {
                RenderMessage("Wrong format. Try again in x,y x,y format: ");
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

        public void RenderGrid(Grid grid)
        {
            var livingCells = grid.GetLivingCells();
//            RenderBorder(grid);
            string gridString = "";
            for (var row = 0; row < grid.Height; row++)
            {
                for (var col = 0; col < grid.Width; col++)
                {
                    gridString += livingCells.Any(cell => cell.Row == row && cell.Column == col) ? "* " : "- ";
                }

                gridString += Environment.NewLine;
            }

            gridString += Environment.NewLine;
            Console.WriteLine(gridString);
        }

        private static void RenderBorder(Grid grid)
        {
            var s = "╔";
            var space = "";

            for (var i = 0; i < grid.Width; i++)
            {
                space += " ";
                s += "═";
            }


            s += "╗" + "\n";

            for (var i = 0; i < grid.Height; i++)
                s += "║" + space + "║" + "\n";

            s += "╚";
            for (var i = 0; i < grid.Width; i++)
                s += "═";

            s += "╝" + "\n";

            Console.Write(s);
        }

        public void RenderMessage(string message)
        {
            Console.Write(message);
        }
    }
}