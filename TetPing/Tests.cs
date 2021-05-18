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
        public void AddBalls()
        {
            Balls.AddBall();
            Balls.AddBall();
            Balls.AddBall();

            Assert.AreEqual(3, Balls.Count);
        }

        [Test]
        public void AddHearts()
        {
            Hearts.AddHeart();
            Hearts.AddHeart();
            Hearts.AddHeart();

            Assert.AreEqual(3, Hearts.Count);
        }

        [Test]
        public void RemoveHearts()
        {
            Hearts.AddHeart();
            Hearts.AddHeart();
            Hearts.RemoveHeart();
            Hearts.RemoveHeart();

            Assert.AreEqual(0, Hearts.Count);
        }
    }
}
