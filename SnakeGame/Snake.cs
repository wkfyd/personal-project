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
        Bitmap snakeHead;
        public int X { get; set; }
        public int Y { get; set; }

        public int Dir { get; set; }

        int speed = 30;
        public Snake(int x, int y)
        {
            X = x;
            Y = y;
            Dir = RIGHT;
            snakeBody = new Bitmap(Properties.Resources.snakeBody);
            snakeHead = new Bitmap(Properties.Resources.SnakeGIF);
        }

        

        public void BodyDraw(Graphics g)
        {
            g.DrawImage(snakeBody, X, Y, 30, 30);
        }

        public void HeadDraw(Graphics g)
        {
            g.DrawImage(snakeHead, X, Y, 30, 30);
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
