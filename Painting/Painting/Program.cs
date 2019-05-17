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
        private bool update2 = true;

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
        public void Update(int Width, int Height)
        {

            if (update2 == true)
            {
                if (x < Height - 100)
                {
                    x++;
                    y++;
                }
                else if (x < Height + 100 && y > 0)
                {
                    x++;
                    y--;
                }
                else if (x < Width - 100 && y < Height - 160)
                {
                    x++;
                    y++;
                }
                else if (x <= Width - 100 && y < Height - 100)
                {
                    x--;
                    y++;
                }
                else
                //(x < Width && y < Height)
                {
                    x++;
                    y--;
                    update2 = false;
                }
            }
            else
                Update2(Width, Height);

        }
        public void Update2(int Width, int Height)
        {
            bool update = true;
            if (update == true) { 
            if (x < Width && y > 0)
            {
                x--;
                y--;
                //update = true;
            }
            }
            else
                //(x<Width && y >= 0)
            {
                x--;
                y++;
                update = false;
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
}
