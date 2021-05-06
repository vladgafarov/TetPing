using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    class Arrow
    {
        private Bitmap ArrowTexture = RotateImage(Resources.Resource1.arrow, 60);
        private PictureBox ArrowItem;

        public Arrow(Control form)
        {
            ArrowItem = new PictureBox
            {
                //BackgroundImage = RotateImage(Resources.Resource1.arrow, 80),
                Image = ArrowTexture,
                SizeMode = PictureBoxSizeMode.Zoom,
                //BackgroundImageLayout = ImageLayout.Zoom,
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.FixedSingle,
                Size = new Size 
                {
                    Width = 120,
                    Height = 120
                },
                Location = new Point
                {
                    X = form.Width / 2 - 50,
                    Y = form.Height - form.Height / 2
                }
            };

            form.Controls.Add(ArrowItem);
        }

        public static Bitmap RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, new Point(0, 0));

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;

        }
    }
}
