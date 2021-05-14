﻿using System;
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
        private Arrow Arrow;
        private Block Block;
        private Map Map;
        private Score Score;
        private bool left;
        private bool right;
        private int DownShiftInterval;

        public Game(Control form)
        {
            //Arrow = new Arrow(form);
            Board = new Board();
            Ball = new Ball();
            Balls = new Balls(Ball);
            Hearts = new Hearts(form);
            GameOver = new GameOver(form);
            Map = new Map();
            Block = new Block();
            Score = new Score(form);

            if (Balls.Count == 3)
                DownShiftInterval = 4800;
            else if (Balls.Count == 2)
                DownShiftInterval = 5100;
            else
                DownShiftInterval = 5400;
        }

        #region gameStates

        public void NewGame(Control form)
        {
            var removedHearts = Hearts.RemovedHearts;
            List<Ball> copyBallsList = new List<Ball>(Balls.BallsList);
            //List<Block> copyBlockList = new List<Block>(Map.BlocksList);

            Board.InitPhysics(left, right, form);

            copyBallsList.ForEach(ball => {
                ball.InitPhysics(form, Board);

                var index = Balls.BallsList.IndexOf(ball);

                if(ball.IsFailed)
                {
                    Hearts.RemoveHeart(form);
                    if(index == 0)
                        ball.IsFailed = false;
                }

                if(index > 0 && ball.IsFailed)
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
                };

            });

            if (Map.IsHiddenPartEmpty(4))
            {
                Block.CreateBlocks(6, 1);
            }

            if(Hearts.Count == 0)
            {
                EndGame();
            }
        }

        public static void EndGame()
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

            Board.Reset();

            //Balls.Reset();

            GameOver.Reset();
        }

        #endregion

        public void Draw(PaintEventArgs e)
        {
            Balls.BallsList.ForEach(ball => ball.Draw(e));
            Map.BlocksList.ForEach(block => block.Draw(e));
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