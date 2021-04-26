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
        private Balls Balls;
        private Ball Ball;
        private Hearts Hearts;
        private GameOver GameOver;
        private Arrow Arrow;
        private Block Block;
        private bool left;
        private bool right;

        public Game(Control form)
        {
            //Arrow = new Arrow(form);
            Board = new Board(form);
            Block = new Block(form);
            Ball = new Ball(form);
            Balls = new Balls(Ball);
            Hearts = new Hearts(form);
            GameOver = new GameOver(form);
        }

        public void NewGame(Control form)
        {
            var removedHearts = Hearts.RemovedHearts;
            List<Ball> copyBallsList = new List<Ball>(Balls.BallsList);

            Board.InitPhysics(left, right, form);

            copyBallsList.ForEach(Ball => {
                Ball.InitPhysics(form, Board);

                if(Ball.IsFailed)
                {
                    Hearts.RemoveHeart(removedHearts);
                    Ball.IsFailed = false;
                }
            });

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

        public void ResetGame(Control form, Timer timer)
        {
            IsGameEnd = false;
            timer.Start();

            Hearts.RemovedHearts = 0;
            Hearts.Reset();

            Board.Reset(form);

            //Balls.Reset();

            GameOver.Reset();
        }

        public void Draw(PaintEventArgs e)
        {
            //Ball.Draw(e);
            //Balls.Draw(e);

            Balls.BallsList.ForEach(Ball => Ball.Draw(e));
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
