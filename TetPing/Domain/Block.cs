using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing.Domain
{
    class Block
    {
        private Image BlockTexture = Resources.Resource1.block;
        private PictureBox BlockItem;
        private const int Size = 30;


        public Block(Control form)
        {
            BlockItem = new PictureBox
            {
                Image = BlockTexture,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size
                {
                    Width = Size,
                    Height = Size
                }
            };

            form.Controls.Add(BlockItem);
        }
    }
}
