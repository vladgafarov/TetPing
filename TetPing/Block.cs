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
        private Image BlockTexture = Resources.Resource1.block;
        private Rectangle block;

        private static Random random = new Random();

        public Block() 
        {
            CreateBlocks(5);
        }

        public Block(int x, int y)
        {
            if (y > 2) y -= 3;
            //else y -= 3;
            block = new Rectangle(x * Size, y * Size, Size, Size);
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

        public static void CreateBlocks(int count)
        {
            BlockTypes BlockType;
            Orientation Orientation;

            int[] last = new int[] { 1, 4 };

            for (var i = 0; i < count; i++)
            {
                BlockType = random.NextEnum<BlockTypes>();
                Orientation = random.NextEnum<Orientation>();
                var quantity = random.Next(3, 9);

                switch (BlockType)
                {
                    case BlockTypes.Line:
                        last = CreateLine(Orientation, last[0], last[1], quantity);
                        break;
                    case BlockTypes.Random:
                        last = CreateRandomForm(Orientation, last[0], last[1], quantity);
                        break;
                }
            }

            Map.Init();
        }

        private static int[] CreateRandomForm(Orientation orientation, int x, int y, int quantity)
        {
            int chance;
            var firstY = y;

            for (var i = 0; i < quantity; i++)
            {
                if (x >= Map.mapWidth - 1) break;
                switch (orientation)
                {
                    case Orientation.Horizontal:
                        if (i % 2 != 0 || i == 0)
                        {
                            Map.map[x, y] = 1;
                            x = i == 0 ? x + 1 : x;
                        }
                        else
                        {
                            chance = random.Next(2);
                            y = chance == 0 ? y + 1 : y - 1;
                            Map.map[x, y] = 1;

                            x += 1;
                            y = chance == 0 ? y - 1 : y + 1;
                        }
                        break;
                    case Orientation.Vertical:
                        if (i % 2 != 0 || i == 0)
                        {
                            Map.map[x, y] = 1;
                            y = i == 0 ? y + 1 : y;
                        }
                        else
                        {
                            chance = random.Next(2);
                            x = chance == 0 ? x + 1 : x - 1;
                            if(x > 0)
                                Map.map[x, y] = 1;

                            y += 1;
                            x = chance == 0 ? x - 1 : x + 1;
                        }
                        break;
                }
            }

            return new int[] { x + 1, firstY };
        }

        private static int[] CreateLine(Orientation orientation, int x, int y, int quantity)
        {
            var last = new int[] { x, y };

            for (var i = 0; i < quantity; i++)
            {
                if (x + i >= Map.mapWidth - 1) break;
                switch (orientation)
                {
                    case Orientation.Horizontal:
                        Map.map[x + i, y] = 1;
                        last[0] = x + i;
                        break;
                    case Orientation.Vertical:
                        Map.map[x, y + i] = 1;
                        break;

                }
            }
            last[0] += 1;
            return last;
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
