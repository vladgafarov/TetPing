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
        private Ball ball;
        private Board board;
        private Game game;

        public Form1()
        {
            InitializeComponent();
            Size = new Size(600, 800);
            StartPosition = FormStartPosition.CenterScreen;

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            UpdateStyles();

            timer1.Interval = 1;
            timer1.Start();
            
            game = new Game(this);
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    game.MoveLeft(true);
                    break;
                case Keys.D:
                case Keys.Right:
                    game.MoveRight(true);
                    break;
            }
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    game.MoveLeft(false);
                    break;
                case Keys.D:
                case Keys.Right:
                    game.MoveRight(false);
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.NewGame(this);
            Refresh();
        }
    }
}
