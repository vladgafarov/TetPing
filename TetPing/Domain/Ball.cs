using System.Drawing;
using System.Windows.Forms;

namespace TetPing.Domain
{
    class Ball
    {
        public bool IsFailed;
        private const int Size = 28;
        private const int Speed = 4;
        private int SpeedHorizontal = Speed;
        private int SpeedVertical = Speed;

        // private Panel ball;
        private Image BallTexture = Resources.Resource1.ball;
        private Rectangle ball;
        private PictureBox some;
        private int X;
        private int Y;
        
        public Ball(Control form)
        {
            X = form.Width / 2 - Size / 2;
            Y = form.Height - form.Height / 6;
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
        
        public void InitPhysics(Control form, Board board)
        {
            ball.X += SpeedHorizontal;
            ball.Y -= SpeedVertical;
            
            //Left, Right
            if (ball.Left <= 0 || ball.Right >= form.Width)
            {
                SpeedHorizontal *= -1;
            }

            //Top
            if (ball.Top <= 0)
                SpeedVertical *= -1;

            //Bottom
            if(ball.Bottom >= form.Bottom)
            {
                IsFailed = true;
                ball.Location = new Point { X = X, Y = Y };
                SpeedVertical *= -1;
            }

            //Board
            if (ball.Right <= board.GetRight() + ball.Width && ball.Bottom >= board.GetTop() && ball.Left >= board.GetLeft() - ball.Width && ball.Top < board.GetTop() + 1)
            {
                SpeedVertical *= -1;
            }
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
