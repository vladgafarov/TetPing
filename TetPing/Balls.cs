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
        public static int Count;
        public static List<Ball> BallsList = new List<Ball>(Count);
        public static int MaxCount = 3;
        private static Ball FirstBall;

        public Balls(Ball firstBall)
        {
            Count = 1;
            FirstBall = firstBall;
            BallsList.Add(FirstBall);
        }

        public static void AddBall()
        {
            Count++;

            var ball = new Ball();
            BallsList.Add(ball);
        }

        public static void Reset()
        {
            BallsList.Clear();
            Count = 1;
            BallsList.Add(new Ball());
        }
    }
}
