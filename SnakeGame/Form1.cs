using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        List<Snake> snakeList;
        Apple apple;
        public Form1()
        {
            snakeList = new List<Snake>();
            snakeList.Add(new Snake(240, 200));
            apple = new Apple(300, 400);
            InitializeComponent();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < snakeList.Count; i++)
            {
                snakeList[i].Draw(e.Graphics);
            }

            apple.AppleDraw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    snakeList[0].Dir = Snake.RIGHT;
                    break;
                case Keys.Left:
                    snakeList[0].Dir = Snake.LEFT;
                    break;
                case Keys.Up:
                    snakeList[0].Dir = Snake.UP;
                    break;
                case Keys.Down:
                    snakeList[0].Dir = Snake.DOWN;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, System.EventArgs e)
        {

            if (snakeList[0].X == apple.X && snakeList[0].Y == apple.Y)
                EatApple();

            for (int i = 1; i < snakeList.Count; i++) 
            {
                snakeList[i].X = snakeList[i-1].X;  
                snakeList[i].Y = snakeList[i-1].Y; 
            }

            snakeList[0].Move(); 

            Invalidate();
        }

        private void EatApple()
        {
            snakeList.Add(new Snake(snakeList[snakeList.Count-1].X, snakeList[snakeList.Count - 1].Y));
        }

    }
}
