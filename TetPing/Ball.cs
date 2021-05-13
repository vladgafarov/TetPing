using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TetPing
{
    class Ball
    {
        public bool IsFailed;
        private const int Size = 28;
        private int Speed = 6;
        private int MaxSpeed = 12;
        private int SpeedHorizontal;
        private int SpeedVertical;

        // private Panel ball;
        private Image BallTexture = Resources.Resource1.ballNew;
        private Rectangle ball;
        private int X;
        private int Y;

        public Ball()
        {
            SpeedHorizontal = Speed;
            SpeedVertical = -Speed;
            X = GameForm.Width / 2 - Size / 2;
            Y = GameForm.Height - GameForm.Height / 5;

            ball = new Rectangle(X, Y, Size, Size);

            //some = new PictureBox
            //{
            //    Size = new Size { Width = Size, Height = Size },
            //    Location = new Point
            //    {
            //        X = X,
            //        Y = Y
            //    },
            //    BackgroundImage = BallTexture,
            //    BackgroundImageLayout = ImageLayout.Center,
            //    BackColor = Color.Transparent
            //};

            //form.Controls.Add(some);
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(BallTexture, ball);
        }
        
        public void InitPhysics(Board board)
        {
            ball.X += SpeedHorizontal;
            ball.Y += SpeedVertical;

            #region walls

            //Left, Right
            if (ball.Left <= 0 || ball.Right >= GameForm.Width)
            {
                SpeedHorizontal *= -1;
            }

            //Top
            if (ball.Top <= 0)
            {
                SpeedVertical *= -1;
            }

            //Bottom
            if(ball.Bottom >= GameForm.Height)
            {
                IsFailed = true;
                ball.Location = new Point { X = X, Y = Y };
                SpeedVertical *= -1;
            }

            #endregion

            //Board
            if (ball.Right <= board.GetRight() + ball.Width && ball.Bottom >= board.GetTop() && ball.Left >= board.GetLeft() - ball.Width && ball.Top < board.GetTop() + 1)
            {
                SpeedVertical *= -1;
            }

            List<Block> copyBlocksList = new List<Block>(Map.BlocksList);

            copyBlocksList.ForEach(block =>
            {
                var rectBlock = block.GetRectBlock();
                var inaccuracy = 7.5;

                var blockBottom = rectBlock.Bottom - inaccuracy;
                var blockTop = rectBlock.Top + inaccuracy;
                var blockLeft = rectBlock.Left + inaccuracy;
                var blockRight = rectBlock.Right - inaccuracy;
                var ballBottom = ball.Bottom;
                var ballTop = ball.Top;
                var ballLeft = ball.Left;
                var ballRight = ball.Right;

                if (ball.IntersectsWith(rectBlock))
                {
                    #region Trajectory

                    // Trajectory
                    // To bottom right
                    if (SpeedVertical > 0 && SpeedHorizontal > 0)
                    {
                        // 1. Top board
                        if (ballBottom <= blockTop && ballRight >= blockLeft)
                            SpeedVertical *= -1;
                        // 2. Left board
                        if (ballBottom > blockTop && ballRight < blockLeft)
                            SpeedHorizontal *= -1;
                    }
                    // To top left
                    if (SpeedVertical < 0 && SpeedHorizontal < 0)
                    {
                        // 1. Bottom board
                        if (ballTop >= blockBottom && ballLeft <= blockRight)
                            SpeedVertical *= -1;
                        // 2. Right board
                        if (ballTop < blockBottom && ballLeft > blockRight)
                            SpeedHorizontal *= -1;
                    }

                    // To top right
                    if (SpeedVertical < 0 && SpeedHorizontal > 0)
                    {
                        // 1. Bottom board
                        if (ballTop >= blockBottom && ballRight >= blockLeft)
                            SpeedVertical *= -1;
                        // 2. Left board
                        if (ballTop < blockBottom && ballRight < blockLeft)
                            SpeedHorizontal *= -1;
                    }
                    // To bottom left
                    if (SpeedVertical > 0 && SpeedHorizontal < 0)
                    {
                        // 1. Top board
                        if (ballBottom <= blockTop && ballLeft <= blockRight)
                            SpeedVertical *= -1;
                        // 2. Right board
                        if (ballBottom > blockTop && ballLeft > blockRight)
                            SpeedHorizontal *= -1;
                    }
                    #endregion

                    if(block.Type == 2 && Balls.Count < Balls.MaxCount)
                    {
                        Balls.AddBall();
                    }

                    if(block.Type == 4 && (int)(Speed * 1.25) <= MaxSpeed)
                    {
                        Speed *= (int)1.25;
                    }

                    block.Remove();
                }
            });
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
