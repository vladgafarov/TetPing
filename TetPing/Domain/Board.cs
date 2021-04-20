using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing.Domain
{
    class Board
    {
        private int Width = 120;
        private int Height = 20;
        private Panel board;
        private const int Speed = 10;

        public Board(Control f1)
        {
            board = new Panel
            {
                Size = new Size { Width = Width, Height = Height },
                Location = new Point
                {
                    X = f1.Width / 2 - Width / 2,
                    Y = f1.Height - f1.Height / 9
                },
                BackColor = Color.BlanchedAlmond
            };
            
            f1.Controls.Add(board);
        }
        
        public void MoveRight()
        {
            board.Left += Speed;
        }

        public void MoveLeft()
        {
            board.Left -= Speed;
        }

        public int GetLeft()
        {
            return board.Left;
        }

        public int GetRight()
        {
            return board.Right;
        }

        public int GetTop()
        {
            return board.Top;
        }

        public void InitMovement(bool left, bool right, Control form)
        {
            if (left && board.Left >= 0)
            {
                MoveLeft();
            }

            if (right && board.Right <= form.Width)
            {
                MoveRight();
            }
        }
    }
}
