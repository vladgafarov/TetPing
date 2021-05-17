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
            Size = new Size(600, 720);
            BackgroundImage = Resources.Resource1.bgNew;
            StartPosition = FormStartPosition.CenterScreen;
            BackgroundImageLayout = ImageLayout.Center;

            var logo = new PictureBox
            {
                Size = new Size
                {
                    Width = 300,
                    Height = 300
                },
                Location = new Point
                {
                    X = Width / 2 - 150,
                    Y = 40
                },
                BackColor = Color.Transparent,
                BackgroundImage = Resources.Resource1.logo,
                BackgroundImageLayout = ImageLayout.Stretch,
            };

            var button = new Button {
                Name = "button1",
                Text = "Play",
                Size = new Size
                {
                    Width = 180,
                    Height = 60
                },
                Font = new Font("Verdana", 22),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point
                {
                    X = Width / 2 - 90,
                    Y = Height / 2 - 30 + 80
                }
            };

            button.Click += button1_Click;

            Controls.Add(button);
            Controls.Add(logo);
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            var game = new GameForm();
            game.Show();
        }
    }
}
