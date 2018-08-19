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
            while (input == null && !Regex.IsMatch(input, "^([1-9][1-9]*?,[1-9][1-9]*?( ?))+?$"))
            {
                RenderMessage("Wrong format. Try again in x,y x,y format.");
                input = Console.ReadLine();
            }

            var coordinates = input.Split(" ");
            var foo = new List<Cell>();
            foreach (var coord in coordinates)
            {
                var row = int.Parse((coord[0] - 1).ToString());
                var column = int.Parse((coord[2] - 1).ToString());
                Console.WriteLine(coord[0] + "," + coord[2]);
                foo.Add(new Cell(row, column));
            }

            Console.WriteLine(" count of lists of cell " + foo.Count);
            return foo.ToList();

//            return coordinates.Select(coord =>
//            {
//                var row = int.Parse((coord[0] - 1).ToString());
//                var column = int.Parse((coord[2] - 1).ToString());
//                return new Cell(row, column);
//            }).ToList();
//            return new List<Cell>
//            {
//                new Cell(0,0),
//                new Cell(1,1),
//                new Cell(0,2),
//                new Cell(1,2),
//                new Cell(2,1)
//               
//            };
        }

        public void RenderGrid(Grid grid)
        {
            var livingCells = grid.GetLivingCells();
//            RenderBorder(grid);
            for (var row = 0; row < grid.Height; row++)
            {
                for (var col = 0; col < grid.Width; col++)
                {
                    Console.Write(livingCells.Any(cell => cell.Row == row && cell.Column == col) ? "* " : "- ");
                }

                Console.Write(Environment.NewLine);
            }

            Console.WriteLine(Environment.NewLine);
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