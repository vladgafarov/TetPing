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

        [Test]
        public void BallIncreaseSpeed()
        {
            var ball = new Ball();
            ball.IncreaseBallSpeed();

            Assert.AreEqual(7, ball.Speed);
        }

        [Test]
        public void MapCellsInit()
        {
            new Map();
            Map.map[0, 0] = BlockType.Standart;
            Map.map[10, 9] = BlockType.Heart;
            Map.map[1, 5] = BlockType.BallSpeed;

            Map.Init();

            Assert.AreEqual(3, Map.BlocksList.Count);
        }
    }
}
