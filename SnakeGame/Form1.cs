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
        Map map;
        Apple apple;

        int score;

        public Form1()
        {
            snakeList = new List<Snake>();
            snakeList.Add(new Snake(240, 210));
            apple = new Apple(360,450);
            map = new Map(780, 660);
            InitializeComponent();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            map.DrawWall(e.Graphics);

            for (int i = 0; i < snakeList.Count; i++)
            {
                if (i == 0)
                    snakeList[i].HeadDraw(e.Graphics);
                else
                {
                    snakeList[i].Draw(e.Graphics);
                }
            }

            apple.AppleDraw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && snakeList[0].Dir != 1)
            {
                snakeList[0].Dir = Snake.RIGHT;
            }
            if (e.KeyCode == Keys.Left && snakeList[0].Dir != 2)
            {
                snakeList[0].Dir = Snake.LEFT;
            }
            if (e.KeyCode == Keys.Down && snakeList[0].Dir != 3)
            {
                snakeList[0].Dir = Snake.DOWN;
            }
            if (e.KeyCode == Keys.Up && snakeList[0].Dir != 4)
            {
                snakeList[0].Dir = Snake.UP;
            }
        }

        private void gameTimer_Tick(object sender, System.EventArgs e)
        {
            

            if (snakeList[0].X == apple.X && snakeList[0].Y == apple.Y)
            {
                EatApple();
            }

            for (int i = snakeList.Count-1; i > 0 ; i--) 
            {
                snakeList[i].X = snakeList[i-1].X;
                snakeList[i].Y = snakeList[i-1].Y;
            }

            snakeList[0].Move();
            GameOver();
            Invalidate();
        }

        private void EatApple()
        {
            score += 1;

            scoreLabel.Text = "Score: " + score;

            snakeList.Add(new Snake(snakeList[snakeList.Count-1].X, snakeList[snakeList.Count - 1].Y));
            apple = new Apple(apple.ApplePosX(), apple.ApplePosY());
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {

            startButton.Enabled = false;
            startButton.Visible = false;
            gameOverLabel.Visible = false;

            snakeList.Clear();

            snakeList = new List<Snake>();
            snakeList.Add(new Snake(240, 210));

            score = 0;
            scoreLabel.Text = "Score: " + score;


            gameTimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gameTimer.Stop();
            gameOverLabel.Visible = false;
        }

        private void GameOver()   //뱀이 자기몸, 혹은 맵 끝과 충돌하는지 확인
        {
            if (snakeList[0].X >= map.X || snakeList[0].Y >= map.Y || snakeList[0].X < 0 || snakeList[0].Y < 0)
            {
                gameTimer.Stop();
                gameOverLabel.Visible = true;
                startButton.Enabled = true;
                startButton.Visible = true;
            }

            for ( int i = 1; i <= snakeList.Count-1; i++)
            {
                if (snakeList[0].X == snakeList[i].X && snakeList[0].Y == snakeList[i].Y)
                {
                    gameTimer.Stop();
                    gameOverLabel.Visible = true;
                    startButton.Enabled = true;
                    startButton.Visible = true;
                }
            }

        }

    }
}
