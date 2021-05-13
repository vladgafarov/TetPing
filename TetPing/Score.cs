using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    class Score
    {
        public static Label ScoreBoard;
        public static int score;

        public Score(Control form)
        {
            ScoreBoard = new Label
            {
                Location = new Point
                {
                    X = 10,
                    Y = 10
                },
                Size = new Size
                {
                    Width = 200,
                    Height = 40
                },
                Text = score.ToString(),
                Font = new Font("Verdana", 22),
                BackColor = Color.Transparent
            };

            form.Controls.Add(ScoreBoard);
        }
    }
}
