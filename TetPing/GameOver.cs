using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    class GameOver
    {
        public static Label Label;
        private int Width = 400;
        private int Height = 360;

        public GameOver(Control form)
        {
            Label = new Label
            {
                Text = "Game over \n Enter - Restart \n Esc - Exit",
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
                Padding = new Padding(0),
                Visible = false
            };

            form.Controls.Add(Label);
        }

        public static void EndTrigger()
        {
            Label.Visible = true;
        }

        public void Reset()
        {
            Label.Visible = false;
        }
    }
}
