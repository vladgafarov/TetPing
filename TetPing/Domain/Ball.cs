using System.Drawing;
using System.Windows.Forms;

namespace TetPing.Domain
{
    class Ball
    {
        private int Size = 32;
        private Panel ball;
        private Image BallTexture = Resource1.ball;
        private Rectangle rect;
        
        public Ball(Control f1)
        {
            rect = new Rectangle(0, 0, Size, Size);
            
            f1.Controls.Add(ball);
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(BallTexture, rect);
        }

    }
}
