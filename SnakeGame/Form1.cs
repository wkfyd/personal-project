using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private List<SnakeBody> Snake = new List<SnakeBody>();
        private SnakeBody food = new SnakeBody();

        int maxWidth;
        int maxHeight;

        int score;

        Random rand = new Random();

        bool goLeft, goRight, goUp, goDown;
        

        public Form1()
        {
            InitializeComponent();

            new Settings();
        }

        private void startGame(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }
        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (goLeft)
                Settings.directions = "left";
            if (goRight)
                Settings.directions = "Right";
            if (goUp)
                Settings.directions = "Up";
            if (goDown)
                Settings.directions = "Down";

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].X--;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "up":
                            Snake[i].Y++;
                            break;
                        case "down":
                            Snake[i].Y--;
                            break;
                    }

                    if (Snake[i].X < 0)
                        Snake[i].X = maxWidth;
                    if (Snake[i].X > maxWidth)
                        Snake[i].X = 0;
                    if (Snake[i].Y < 0)
                        Snake[i].Y = maxHeight;
                    if (Snake[i].Y > maxHeight)
                        Snake[i].Y = 0;

                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }

            map.Invalidate();
        }

        private void UpdatePictureBoxGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            Brush snakeColor;

            for(int i = 0; i < Snake.Count; i++)
            {
                if( i == 0)
                {
                    snakeColor = Brushes.Black;
                }
                else
                {
                    snakeColor = Brushes.DarkGreen;
                }

                canvas.FillEllipse(snakeColor, new Rectangle
                    (
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
            }

            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
                    (
                    food.X * Settings.Width,
                    food.Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
        }



        private void RestartGame()
        {
            maxWidth = map.Width / Settings.Width - 1;
            maxHeight = map.Height / Settings.Height - 1;

            Snake.Clear();

            startButton.Enabled = false;

            score = 0;
            scoreLabel.Text = "Score: " + score;

            SnakeBody head = new SnakeBody { X = 10, Y = 5 };
            Snake.Add(head);

            for (int i = 0; i < 10; i++)
            {
                SnakeBody body = new SnakeBody();
                Snake.Add(body);
            }

            food = new SnakeBody { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };

            gameTimer.Start();
        }

        private void EatFood()
        {

        }

        private void GameOver()
        {

        }
    }
}
