using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    enum Orientation
    {
        Horizontal,
        Vertical
    }

    class Block
    {
        public const int Size = 40;
        private Image BlockTexture = Resources.Resource1.blockNew;
        private Rectangle block;
        private int MapX;
        private int MapY;
        private int Y;
        private int Type;

        private static Random random = new Random();

        public Block() 
        {
            CreateBlocks(5, 4);
        }

        public Block(int x, int y, int type)
        {
            MapX = x;
            MapY = y;
            Type = type;
            Y = y;
            Y -= 3;
            block = new Rectangle(x * Size, Y * Size, Size, Size);
        }

        #region utils

        public void SetLocation(int x, int y)
        {
            block.X = x * Size;
            block.Y = y * Size;
        }

        public void SetX(int x)
        {
            block.X = x * Size;
        }

        public void SetY(int y)
        {
            block.Y = y * Size;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(BlockTexture, block);
        }

        public void Remove(Block block)
        {
            var index = Map.BlocksList.IndexOf(block);
            if(index >= 0)
                Map.BlocksList.RemoveAt(index);
        }

        public Rectangle GetRectBlock()
        {
            return block;
        }
        #endregion

        public static void CreateBlocks(int count, int y)
        {
            BlockTypes BlockType;
            Orientation Orientation;

            var lastX = 1;

            for (var i = 0; i < count; i++)
            {
                BlockType = random.NextEnum<BlockTypes>();
                Orientation = random.NextEnum<Orientation>();
                var quantity = random.Next(3, 9);

                switch (BlockType)
                {
                    case BlockTypes.Line:
                        lastX = CreateLine(Orientation, lastX, y, quantity);
                        break;
                    case BlockTypes.Random:
                        lastX = CreateRandomForm(Orientation, lastX, y, quantity);
                        break;
                }
            }

            Map.Init();
        }

        private static int CreateRandomForm(Orientation orientation, int x, int y, int quantity)
        {
            int chance;

            for (var i = 0; i < quantity; i++)
            {
                if (x >= Map.mapWidth - 1) break;
                switch (orientation)
                {
                    case Orientation.Horizontal:
                        if (i % 2 != 0 || i == 0)
                        {
                            Map.map[y, x] = 1;
                            x = i == 0 ? x + 1 : x;
                        }
                        else
                        {
                            chance = random.Next(2);
                            y = chance == 0 ? y + 1 : y - 1;
                            Map.map[y, x] = 1;

                            x += 1;
                            y = chance == 0 ? y - 1 : y + 1;
                        }
                        break;
                    case Orientation.Vertical:
                        if (i % 2 != 0 || i == 0)
                        {
                            Map.map[y, x] = 1;
                            y = i == 0 ? y + 1 : y;
                        }
                        else
                        {
                            chance = random.Next(2);
                            x = chance == 0 ? x + 1 : x - 1;
                            if(x > 0)
                                Map.map[y, x] = 1;

                            y += 1;
                            x = chance == 0 ? x - 1 : x + 1;
                        }
                        break;
                }
            }

            return x;
        }

        private static int CreateLine(Orientation orientation, int x, int y, int quantity)
        {
            var lastX = x;

            for (var i = 0; i < quantity; i++)
            {
                if (x + i >= Map.mapWidth - 1) break;
                switch (orientation)
                {
                    case Orientation.Horizontal:
                        Map.map[y, x + i] = 1;
                        lastX = x + i;
                        break;
                    case Orientation.Vertical:
                        Map.map[y + i, x] = 1;
                        break;

                }
            }
            return lastX + 1;
        }

        public void DownShift()
        {
            var nextY = Y + 1;

            if (nextY == Map.mapHeight - 4)
                Game.EndGame();

            SetY(nextY);
            Map.map[MapY, MapX] = 0;
            Map.map[MapY + 1, MapX] = Type;

            Y += 1;
            MapY += 1;
        }
    }

    public static class RandomExtensions
    {
        public static T NextEnum<T>(this Random random)
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(random.Next(values.Length));
        }
    }
}
