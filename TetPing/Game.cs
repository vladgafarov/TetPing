using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TetPing
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
        private Blocks Blocks;
        private Map Map;
        private bool left;
        private bool right;

        public Game(Control form)
        {
            //Arrow = new Arrow(form);
            Board = new Board(form);
            Ball = new Ball(form);
            Balls = new Balls(Ball);
            Hearts = new Hearts(form);
            GameOver = new GameOver(form);
            Map = new Map(form);
            Block = new Block();
        }

        public void NewGame(Control form)
        {
            var removedHearts = Hearts.RemovedHearts;
            List<Ball> copyBallsList = new List<Ball>(Balls.BallsList);

            Board.InitPhysics(left, right, form);

            copyBallsList.ForEach(ball => {
                ball.InitPhysics(form, Board);

                if(ball.IsFailed)
                {
                    Hearts.RemoveHeart(removedHearts);
                    ball.IsFailed = false;
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
            Balls.BallsList.ForEach(ball => ball.Draw(e));
            //Blocks.BlocksList.ForEach(block => block.Draw(e));
            Map.BlocksList.ForEach(block => block.Draw(e));
        }

        public void MoveRight(bool isRight)
        {
            right = isRight;
        }
        
        public void MoveLeft(bool isLeft)
        {
            left = isLeft;
        }

        private void InitBlocks(Control form)
        {
            int x = 30;
            int y = 30;
            Blocks blocks = new Blocks(form, x, y, 3);
        }
    }
}
