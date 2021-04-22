using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing.Domain
{
    class Heart
    {
        private static int Width = 37;
        private static int Height = 32;
        private static Image HeartTexture = Resources.Resource1.heart;
        private static Image WithoutHeartTexture = Resources.Resource1.withoutHeart;
        private PictureBox HeartItem;

        public Heart(Control form, int index)
        {
            HeartItem = new PictureBox
            {
                Size = new Size { Width = Width, Height = Height },
                Location = new Point {
                    X = form.Width - index * 40 - 60,
                    Y = form.Top + 20
                },
                BackgroundImage = HeartTexture,
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Color.Transparent
            };

            form.Controls.Add(HeartItem);
        }

        public void ChangeBg()
        {
            if (HeartItem.BackgroundImage == HeartTexture)
                HeartItem.BackgroundImage = WithoutHeartTexture;
            else
                HeartItem.BackgroundImage = HeartTexture;
        }
    }
}
