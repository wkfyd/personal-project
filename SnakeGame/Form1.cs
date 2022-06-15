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

        int speed = 10;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            snakeBodyList.Add(new SnakeBody(e));
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int i;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    for ( i = 0; i < 1; i++ )
                    {
                         snakeBodyList[i].X += 10;
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, System.EventArgs e)
        {
            

        }

    }
}
