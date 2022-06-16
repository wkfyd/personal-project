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
        List<SnakeBody> snakeBodyList = new List<SnakeBody>();

        public Form1()
        {
            snakeBodyList = new List<SnakeBody>();
            snakeBodyList.Add(new SnakeBody(250, 200));
            snakeBodyList.Add(new SnakeBody(230, 200));
            InitializeComponent();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < snakeBodyList.Count; i++)
            {
                snakeBodyList[i].Draw(e.Graphics);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int i;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    for (i = 0; i < snakeBodyList.Count; i++)
                    {
                        snakeBodyList[i].Dir = SnakeBody.RIGHT;
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, System.EventArgs e)
        {
            for (int i = 0; i < snakeBodyList.Count; i++)
            {
                snakeBodyList[i].Move();
            }
            Invalidate();

        }

    }
}
