using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    class Balls
    {
        public static int Count = 1;
        public static List<Ball> BallsList = new List<Ball>(Count);
        private static Ball FirstBall;

        public Balls(Ball firstBall)
        {
            FirstBall = firstBall;
            BallsList.Add(FirstBall);
        }

        public static void AddBall(Control form)
        {
            Count++;

            var ball = new Ball(form);
            BallsList.Add(ball);
        }

        public static void Reset()
        {
            BallsList.ForEach(ball => ball.Dispose());
        }
    }
}
