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
            var input = Console.ReadLine();
            while (input == null && !Regex.IsMatch(input, "^[0-9],[0-9] +?$"))
            {
                RenderMessage("Wrong format. Try again in x,y x,y format.");
                input = Console.ReadLine();
            }

            var coordinates = input.Split(" ");
            return coordinates.Select(coord => new Cell(coord[0], coord[2])).ToList();
        }

        public void RenderGrid(Grid grid)
        {
            var livingCells = grid.GetLivingCells();
            RenderBorder(grid);
            for (var row = 0; row < grid.Height; row++)
            {
                for (var col = 0; col < grid.Width; col++)
                {
                    Console.Write(livingCells.Any(cell => cell.Row == row && cell.Column == col) ? "*" : " ");
                }
            }
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
                s +=   "║" + space + "║" + "\n";

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