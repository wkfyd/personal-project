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
        List<Snake> snakeList = new List<Snake>();

        public Form1()
        {
            snakeList = new List<Snake>();
            snakeList.Add(new Snake(250, 200));
            snakeList.Add(new Snake(230, 200));
            InitializeComponent();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < snakeList.Count; i++)
            {
                snakeList[i].Draw(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int i;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    for (i = 0; i < snakeList.Count; i++)
                    {
                        snakeList[i].Dir = SnakeBody.RIGHT;
                    }
                    break;
                case Keys.Left:
                    for (i = 0; i < snakeList.Count; i++)
                    {
                        snakeList[i].Dir = SnakeBody.LEFT;
                    }
                    break;
                case Keys.Up:
                    for (i = 0; i < snakeList.Count; i++)
                    {
                        snakeList[i].Dir = SnakeBody.UP;
                    }
                    break;
                case Keys.Down:
                    for (i = 0; i < snakeList.Count; i++)
                    {
                        snakeList[i].Dir = SnakeBody.DOWN;
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, System.EventArgs e)
        {
            for (int i = 0; i < snakeList.Count; i++)
            {
                snakeList[i].Move();
            }
            Invalidate();
        }

    }
}
