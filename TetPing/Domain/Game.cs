using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing.Domain
{
    class Game
    {
        private Board board;
        private Ball ball;
        private bool left;
        private bool right;

        public Game(Control form)
        {
            board = new Board(form);
            ball = new Ball(form);
        }

        public void NewGame(Control form)
        {
            board.InitMovement(left, right, form);
            ball.InitMovement(form, board);
        }

        public void Draw(PaintEventArgs e)
        {
            ball.Draw(e);
        }

        public void MoveRight(bool isRight)
        {
            right = isRight;
        }
        
        public void MoveLeft(bool isLeft)
        {
            left = isLeft;
        }
    }
}
