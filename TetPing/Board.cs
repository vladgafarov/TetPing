using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    class Board
    {
        private int Width = 120;
        private int Height = 32;
        private const int Speed = 18;
        private Image BoardTexture = Resources.Resource1.board1;
        private Rectangle board;
        private int X;
        private int Y;
        private int index;

        public Board()
        {
            X = GameForm.Width / 2 - Width / 2;
            Y = GameForm.Height - 120;

            board = new Rectangle(X, Y, Width, Height);
        }
        
        public void MoveRight()
        {
            board.X += Speed;
        }

        public void MoveLeft()
        {
            board.X -= Speed;
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

        public Rectangle GetRect()
        {
            return board;
        }

        public void InitPhysics(bool left, bool right, Control form)
        {
            if (left && board.Left >= 0)
            {
                MoveLeft();
            }

            if (right && board.Right <= GameForm.Width)
            {
                MoveRight();
            }
        }

        public void Reset()
        {
            board.Location = new Point
            {
                X = X,
                Y = Y
            };
        }

        public void Draw(PaintEventArgs e)
        {
            //index++;
            //if (index == 0) BoardTexture = Resources.Resource1.board1;
            //if (index == 1) BoardTexture = Resources.Resource1.board2;
            //if (index == 2) BoardTexture = Resources.Resource1.board3;
            //if (index > 2) index = 0;
            e.Graphics.DrawImage(BoardTexture, board);
        }
    }
}
