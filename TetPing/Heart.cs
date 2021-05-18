using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    class Heart
    {
        private static int Width = 37;
        private static int Height = 32;
        private static Image HeartTexture = Resources.Resource1.heartNew;
        public Rectangle heart;

        public Heart(int index)
        {
            heart = new Rectangle(GameForm.Width - index * 40 - 60, 20, Width, Height);
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(HeartTexture, heart);
        }
    }
}
