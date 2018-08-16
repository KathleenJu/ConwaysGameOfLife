using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Conway's Game of Life");
            var renderer = new ConsoleRenderer();
            renderer.RenderGrid(new Grid(10,20));
            renderer.RenderMessage("Type in a coordinates of our initial grid in this format - 0,0 1,1 0,2");
        }
    }
}