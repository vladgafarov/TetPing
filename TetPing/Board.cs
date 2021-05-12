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
        private const int Speed = 15;
        private Image BoardTexture = Resources.Resource1.boardNew;
        private Rectangle board;
        private int X;
        private int Y;

        public Board()
        {
            X = GameForm.Width / 2 - Width / 2;
            Y = GameForm.Height - GameForm.Height / 7;

            board = new Rectangle(X, Y, Width, Height);
            //board = new Panel
            //{
            //    Size = new Size { Width = Width, Height = Height },
            //    Location = new Point
            //    {
            //        X = form.Width / 2 - Width / 2,
            //        Y = form.Height - form.Height / 9
            //    },
            //    BackColor = Color.Transparent,
            //    BackgroundImage = BoardTexture,
            //    BackgroundImageLayout = ImageLayout.Stretch
            //};
            
            //form.Controls.Add(board);
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
            e.Graphics.DrawImage(BoardTexture, board);
        }
    }
}
