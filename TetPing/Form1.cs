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
    public partial class Form1 : Form
    {
        private int boardSpeed = 20;

        public Form1()
        {
            InitializeComponent();

            board.Top = bg.Bottom - (bg.Bottom / 10);
            board.Width = 200;
            board.Height = 50;
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                if (board.Left > bg.Left)
                    board.Left -= boardSpeed;

            }
            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
                if (board.Right < bg.Width)
                    board.Left += boardSpeed;
        }
    }
}
