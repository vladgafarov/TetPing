using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetPing.Domain;

namespace TetPing
{
    public partial class Form1 : Form
    {
        private int boardSpeed = 20;

        public Form1()
        {
            InitializeComponent();
            Size = new Size(600, 800);
            StartPosition = FormStartPosition.CenterScreen;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            UpdateStyles();
            


            //board.Top = bg.Bottom - (bg.Bottom / 10);
            //board.Width = 200;
            //board.Height = 50;
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            //{
            //    if (board.Left > bg.Left)
            //        board.Left -= boardSpeed;

            //}
            //if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            //    if (board.Right < bg.Width)
            //        board.Left += boardSpeed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //var ball = new Ball(this,e, 200, 200);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var ball = new Ball(this, e, 200, 200);
            var board = new Board(this);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
