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

        private Random random = new Random();
        private BlockTypes BlockType;
        private Orientation Orientation;
        private int Count = 2;

        public Block() 
        {
            CreateBlocks();
            Map.Init();
        }

        public Block(int x, int y)
        {
            block = new Rectangle(x * Size, y * Size, Size, Size);
        }

        #region physics

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
        #endregion

        public void CreateBlocks()
        {
            for (var i = 0; i < Count; i++)
            {
                BlockType = random.NextEnum<BlockTypes>();
                Orientation = random.NextEnum<Orientation>();
                var quantity = random.Next(3, 9);

                switch (BlockType)
                {
                    case BlockTypes.Line:
                        CreateLine(Orientation, 1, 1, quantity);
                        break;
                    case BlockTypes.L:
                        CreateRandomForm(Orientation, 1, 1, quantity);
                        break;
                    //default:
                    //    CreateRandomForm(form, Orientation, 0, 0, quantity);
                    //    break;
                }
            }
        }

        private void CreateRandomForm(Orientation orientation, int x, int y, int quantity)
        {
            int chance;

            for (var i = 0; i < quantity; i++)
            {
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
                            Map.map[x, y] = 1;

                            y += 1;
                            x = chance == 0 ? x - 1 : x + 1;
                        }
                        break;
                }
            }
        }

        private void CreateLine(Orientation orientation, int x, int y, int quantity)
        {
            for (var i = 0; i < quantity; i++)
            {
                switch (orientation)
                {
                    case Orientation.Horizontal:
                        Map.map[x + i, y] = 1;
                        break;
                    case Orientation.Vertical:
                        Map.map[x, y + i] = 1;
                        break;
                }
            }
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
