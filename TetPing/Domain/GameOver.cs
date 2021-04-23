using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing.Domain
{
    class GameOver
    {
        private Label Label;
        private int Width = 300;
        private int Height = 100;

        public GameOver(Control form)
        {
            Label = new Label
            {
                Text = "Game over Enter",
                Font = new Font("Courier New", 32),
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size
                {
                    Width = Width,
                    Height = Height
                },
                Location = new Point
                {
                    X = form.Width / 2 - Width / 2,
                    Y = form.Height / 2 - Height / 2 - 30
                },
                BackColor = Color.BurlyWood,
                Visible = false
            };

            form.Controls.Add(Label);
        }

        public void EndTrigger()
        {
            Label.Visible = true;
        }

        public void Reset()
        {
            Label.Visible = false;
        }
    }
}
