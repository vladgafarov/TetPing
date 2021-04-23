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
        private Image BoardTexture = Resources.Resource1.board;

        public Board(Control form)
        {
            board = new Panel
            {
                Size = new Size { Width = Width, Height = Height },
                Location = new Point
                {
                    X = form.Width / 2 - Width / 2,
                    Y = form.Height - form.Height / 9
                },
                BackColor = Color.Transparent,
                BackgroundImage = BoardTexture,
                BackgroundImageLayout = ImageLayout.Stretch
            };
            
            form.Controls.Add(board);
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

        public void InitPhysics(bool left, bool right, Control form)
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

        public void Reset(Control form)
        {
            board.Location = new Point
            {
                X = form.Width / 2 - Width / 2,
                Y = form.Height - form.Height / 9
            };
        }
    }
}
