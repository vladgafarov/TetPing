using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            Size = new Size(600, 600);

            var button = new Button {
                Name = "button1",
                //Tag = "button1",
                Text = "Play",
                Size = new Size
                {
                    Width = 120,
                    Height = 40
                },
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point
                {
                    X = Width / 2 - 60,
                    Y = Height / 2 - 20
                }
            };

            button.Click += button1_Click;

            Controls.Add(button);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var game = new GameForm();
            game.Show();
        }
    }
}
