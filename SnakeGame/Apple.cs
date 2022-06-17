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

        Random rand;

        List<int> applePosX;
        List<int> applePosY;

        public int X { get; set; }
        public int Y { get; set; }
        public Apple(int x, int y)
        {
            foodApple = new Bitmap(Properties.Resources.Apple);
            rand = new Random();
            applePosX = new List<int>();
            applePosY = new List<int>();
            X = x;
            Y = y;
        }

        public void AppleDraw(Graphics g)
        {
            g.DrawImage(foodApple, X, Y, 30, 30);
        }
        
        public int ApplePosX()
        {
            for(int i = 0; i <= 750; i++)
            {
                if (i%30 == 0)
                {
                    applePosX.Add(i);
                }
            }
            return applePosX[rand.Next(applePosX.Count - 1)];
        }
        public int ApplePosY()
        {
            for (int i = 0; i <= 630; i++)
            {
                if (i % 30 == 0)
                {
                    applePosY.Add(i);
                }
            }
            return applePosY[rand.Next(applePosY.Count - 1)];
        }
    }
}
