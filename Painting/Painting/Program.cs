using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleGraphics graphics = new ConsoleGraphics();

            uint color = 0xFFFF0000;
            int xStart = 0;
            int xEnd = 100;
            int yStart = 0;
            int yEnd = 100;
            int thickness = 5;

            graphics.DrawLine(color, xStart, yStart, xEnd, yEnd, thickness);

            graphics.FlipPages();

            Console.ReadLine();
        }
    }
}
