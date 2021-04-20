using System.Drawing;
using System.Windows.Forms;

namespace TetPing.Domain
{
    class Ball
    {
        private const int Size = 28;
        private const int Speed = 4;
        private int SpeedHorizontal = Speed;
        private int SpeedVertical = Speed;
        
        // private Panel ball;
        private Image BallTexture = Resource1.ball;
        private Rectangle ball;
        private PictureBox some;
        
        public Ball(Control form)
        {
            var x = form.Width / 2 - Size / 2;
            var y = form.Height - form.Height / 6;
            ball = new Rectangle(x, y, Size, Size);
            
            some = new PictureBox
            {
                Size = new Size { Width = Size, Height = Size },
                Location = new Point
                {
                    X = x,
                    Y = y
                },
                BackgroundImage = BallTexture,
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Color.Transparent
            };
            
            form.Controls.Add(some);
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(BallTexture, ball);
        }
        
        public void Move(Control form)
        {
            ball.X += SpeedHorizontal;
            ball.Y -= SpeedVertical;
            
            if (ball.Left <= 0 || ball.Right >= form.Width)
                SpeedHorizontal *= -1;
            if (ball.Top <= 0)
                SpeedVertical *= -1;
            
            // if(ball.Right <= board.Right + ball.Width - 1 && ball.Bottom == board.Top && ball.Left >= board.Left - ball.Width + 1)
            // {
            //     SpeedVertical *= -1;
            // }
        }
    }
}
