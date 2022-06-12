using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    class SnakeBody
    {
        public int X { get; set; }
        public int Y { get; set; }
        public SnakeBody()
        {
            X = 0;
            Y = 0;
        }
    }
}
