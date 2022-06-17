using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    class Map
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Map(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void DrawWall(Graphics g)
        {
            g.DrawRectangle(Pens.Red, 0, 0, X, Y);
        }
    }
}
