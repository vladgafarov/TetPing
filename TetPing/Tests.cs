using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    [TestFixture]

    public class Tests
    {
        [Test]
        public void AddBall()
        {
            Balls.AddBall();
            Balls.AddBall();
            Balls.AddBall();

            Assert.AreEqual(Balls.BallsList.Count, 3);
        }

        //[Test]
        //public void RemoveHeart(Control form)
        //{
        //    var hearts = new Hearts(form);
        //    Hearts.RemoveHeart(2);

        //    Assert.AreEqual(Hearts.RemovedHearts, 1);
        //}
    }
}
