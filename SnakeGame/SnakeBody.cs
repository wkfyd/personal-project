using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    class SnakeBody //뱀의 몸을 생성
    {
        Bitmap snakeBody = new Bitmap(Properties.Resources.SnakeBody);
        Graphics g;
        public int X { get; set; }
        public int Y { get; set; }
        public SnakeBody(PaintEventArgs e)
        {
            X = 250;
            Y = 200;
            g = e.Graphics;
            g.DrawImage(snakeBody, X, Y, 20, 20);
        }

    }
}
