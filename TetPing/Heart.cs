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
        public PictureBox HeartItem;
        public Rectangle heart;

        public Heart(int index)
        {
            heart = new Rectangle(GameForm.Width - index * 40 - 60, 20, Width, Height);

            //HeartItem = new PictureBox
            //{
            //    Size = new Size { Width = Width, Height = Height },
            //    Location = new Point {
            //        X = form.Width - index * 40 - 60,
            //        Y = 20
            //    },
            //    BackgroundImage = HeartTexture,
            //    BackgroundImageLayout = ImageLayout.Stretch,
            //    BackColor = Color.Transparent

            //};

            //form.Controls.Add(HeartItem);
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(HeartTexture, heart);
        }
    }
}
