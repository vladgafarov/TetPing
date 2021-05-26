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
        public static int Speed = 18;
        public static int MaxSpeed = 30;
        private Image BoardTexture = Resources.Resource1.board1;
        private Rectangle board;
        private int X;
        private int Y;

        public Board()
        {
            X = GameForm.Width / 2 - Width / 2;
            Y = GameForm.Height - 120;

            board = new Rectangle(X, Y, Width, Height);
        }

        private void MoveRight()
        {
            board.X += Speed;
        }

        private void MoveLeft()
        {
            board.X -= Speed;
        }

        public Rectangle GetRect()
        {
            return board;
        }

        public void InitPhysics(bool left, bool right)
        {
            if (left && board.Left >= 0)
                MoveLeft();

            if (right && board.Right <= GameForm.Width)
                MoveRight();
        }

        public void Reset()
        {
            board.Location = new Point
            {
                X = X,
                Y = Y
            };
            Speed = 18;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(BoardTexture, board);
        }
    }
}
