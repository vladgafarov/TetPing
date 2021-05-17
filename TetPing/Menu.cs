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
            BackgroundImageLayout = ImageLayout.Center;

            var button = new Button {
                Name = "button1",
                //Tag = "button1",
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
                    Y = Height / 2 - 30
                }
            };

            button.Click += button1_Click;
            //this.OnFormClosed += Menu_FormClosing;

            Controls.Add(button);
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
