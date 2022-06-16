using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    class Apple
    {
        Bitmap foodApple;
        public int X { get; set; }
        public int Y { get; set; }
        public Apple(int x, int y)
        {
            X = x;
            Y = y;
            foodApple = new Bitmap(Properties.Resources.Apple);
        }

        public void AppleDraw(Graphics g)
        {
            g.DrawImage(foodApple, X, Y, 20, 20);
        }
    }
}
