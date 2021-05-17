﻿using System;
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
        private static Image WithoutHeartTexture = Resources.Resource1.withoutHeart;
        public PictureBox HeartItem;

        public Heart(Control form, int index)
        {
            HeartItem = new PictureBox
            {
                Size = new Size { Width = Width, Height = Height },
                Location = new Point {
                    X = form.Width - index * 40 - 60,
                    Y = 20
                },
                BackgroundImage = HeartTexture,
                BackgroundImageLayout = ImageLayout.Stretch,
                BackColor = Color.Transparent
            };

            form.Controls.Add(HeartItem);
        }
    }
}
