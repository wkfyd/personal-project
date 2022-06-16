using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    class Snake
    {
        public const int LEFT = 1;
        public const int RIGHT = 2;
        public const int UP = 3;
        public const int DOWN = 4;

        Bitmap snakeBody;
        public int X { get; set; }
        public int Y { get; set; }

        public int Dir { get; set; }

        int speed = 10;
        public Snake(int x, int y)
        {
            X = x;
            Y = y;
            Dir = RIGHT;
            snakeBody = new Bitmap(Properties.Resources.SnakeBody);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(snakeBody, X, Y, 20, 20);
        }

        public void Move()
        {
            if (Dir == LEFT)
                X -= speed;
            else if (Dir == RIGHT)
                X += speed;
            else if (Dir == UP)
                Y -= speed;
            else if (Dir == DOWN)
                Y += speed;
        }


    }
}
