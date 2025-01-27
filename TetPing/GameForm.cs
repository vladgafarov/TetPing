﻿using System;
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
    public partial class GameForm : Form
    {
        private Game game;
        public new static int Width = 600;
        public new static int Height = 720;
        public static int Time;

        public GameForm()
        {
            InitializeComponent();
            BackgroundImage = Resources.Resource1.bgNew;
            BackgroundImageLayout = ImageLayout.Center;
            Size = new Size(Width, Height);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ping-Break-Pong";

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();

            timer1.Interval = 30;
            timer1.Start();
            
            game = new Game(this);
        }

        private void SetDirection(KeyEventArgs e, KeyDirection direction)
        {
            var isKeyDown = direction == KeyDirection.Down;

            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    game.MoveLeft(isKeyDown);
                    break;
                case Keys.D:
                case Keys.Right:
                    game.MoveRight(isKeyDown);
                    break;
            }
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            SetDirection(e, KeyDirection.Down);
            if(Game.IsGameEnd && e.KeyCode == Keys.Enter)
            {
                game.ResetGame(timer1);
            }
            if (Game.IsGameEnd && e.KeyCode == Keys.Escape)
            {
                //Hide();
                //var Menu = new Menu();
                //Menu.Show();
                Application.Exit();
            }
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            SetDirection(e, KeyDirection.Up);
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
            Invalidate();
            //Refresh();
            Time += timer1.Interval;
            game.NewGame(this);

            if(Game.IsGameEnd)
                timer1.Stop();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
