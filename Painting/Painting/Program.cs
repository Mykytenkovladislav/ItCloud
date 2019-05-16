using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting
{
    class Rectangle
    {
        private uint color;
        private int x, y, w, h;

        public Rectangle(uint color, int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            this.color = color;
        }
        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(color, x, y, w, h);
        }
        public void Update(int width, int hight)
        {
            if (y < hight) { 
            x++;
            y++;
            }
            else if (x > width)
            {
                x++;
                y--;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ConsoleGraphics graphics = new ConsoleGraphics();

            Rectangle r = new Rectangle(0xFFFF0000, 0, 0, 100, 100);

            while (true)
            {
                graphics.FillRectangle(0x0FFFFFFF, 0, 0, graphics.ClientWidth, graphics.ClientHeight);
                r.Update(graphics.ClientWidth, graphics.ClientHeight);

                r.Render(graphics);

                graphics.FlipPages();
                System.Threading.Thread.Sleep(1);
            }
        }
    }
}
