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
        private Board Board;
        private Ball Ball;
        private bool left;
        private bool right;

        public Game(Control form)
        {
            Board = new Board(form);
            Ball = new Ball(form);
        }

        public void NewGame(Control form)
        {
            Board.InitPhysics(left, right, form);
            Ball.InitPhysics(form, Board);
        }

        public void Draw(PaintEventArgs e)
        {
            Ball.Draw(e);
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
