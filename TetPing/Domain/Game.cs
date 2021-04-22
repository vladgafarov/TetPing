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
        public bool IsGameEnd;
        private Board Board;
        private Ball Ball;
        private Hearts Hearts;
        private GameOver GameOver;
        private bool left;
        private bool right;

        public Game(Control form)
        {
            Board = new Board(form);
            Ball = new Ball(form, 0);
            Hearts = new Hearts(form);
            GameOver = new GameOver(form);
        }

        public void NewGame(Control form)
        {
            Board.InitPhysics(left, right, form);
            Ball.InitPhysics(form, Board);

            var removedHearts = Hearts.RemovedHearts;

            if(Ball.IsFailed)
            {
                Hearts.RemoveHeart(removedHearts);
                Ball.IsFailed = false;
            }

            if(removedHearts == Hearts.Count)
            {
                EndGame();
            }
        }

        public void EndGame()
        {
            IsGameEnd = true;
            GameOver.EndTrigger();
        }

        public void ResetGame(Timer timer)
        {
            IsGameEnd = false;
            timer.Start();

            Hearts.RemovedHearts = 0;
            Hearts.Reset();

            GameOver.ResetTrigger();
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
