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
        public static bool IsGameEnd;
        private Board Board;
        private Balls Balls;
        private Ball Ball;
        private Hearts Hearts;
        private GameOver GameOver;
        private Block Block;
        private Map Map;
        private Score Score;
        private bool left;
        private bool right;
        private int DownShiftInterval;

        public Game(Control form)
        {
            Board = new Board();
            Ball = new Ball();
            Balls = new Balls(Ball);
            Hearts = new Hearts();
            GameOver = new GameOver(form);
            Map = new Map();
            Block = new Block();
            Score = new Score(form);

            DownShiftInterval = 5400;
        }

        #region gameStates

        public void NewGame(Control form)
        {
            List<Ball> copyBallsList = new List<Ball>(Balls.BallsList);
            //List<Block> copyBlockList = new List<Block>(Map.BlocksList);

            if (Balls.Count == 3)
                DownShiftInterval = 2700;
            else if (Balls.Count == 2)
                DownShiftInterval = 3900;
            else
                DownShiftInterval = 5400;

            Board.InitPhysics(left, right, form);

            copyBallsList.ForEach(ball => {
                ball.InitPhysics(form, Board);

                var index = Balls.BallsList.IndexOf(ball);

                if(ball.IsFailed)
                {
                    Hearts.RemoveHeart();
                    if(Balls.Count == 1)
                        ball.IsFailed = false;
                }

                if(Balls.Count > 1 && ball.IsFailed)
                {
                    Balls.BallsList.Remove(ball);
                    Balls.Count -= 1;
                }
            });

            Map.BlocksList.ForEach(block =>
            {
                if (GameForm.time % DownShiftInterval == 0)
                {
                    block.DownShift();
                    GameForm.time = 0;
                };

            });

            if (Map.IsHiddenPartEmpty(5))
                Block.CreateBlocks(6, 1);

            if(Hearts.Count == 0)
                EndGame();
        }

        public static void EndGame()
        {
            IsGameEnd = true;
            GameOver.EndTrigger();
        }

        public void ResetGame(Control form, Timer timer)
        {
            IsGameEnd = false;
            timer.Start();

            Score.score = 0;
            Score.ScoreBoard.Text = "0";

            Hearts.Reset();
            Board.Reset();
            Map.Reset();
            Balls.Reset();
            GameOver.Reset();
        }

        #endregion

        public void Draw(PaintEventArgs e)
        {
            Balls.BallsList.ForEach(ball => ball.Draw(e));
            Map.BlocksList.ForEach(block => block.Draw(e));
            Hearts.HeartsList.ForEach(heart => heart.Draw(e));
            Board.Draw(e);
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
