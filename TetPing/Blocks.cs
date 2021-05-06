using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{

    class Blocks
    {
        private Random random = new Random();
        private BlockTypes BlockType;
        private Orientation Orientation;
        private int Count;
        private int X;
        private int Y;
        public List<Block> BlocksList = new List<Block>();

        public Blocks(Control form, int x, int y, int count)
        {
            Count = count;
            X = x;
            Y = y;

            Init(form);
        }

        public void Init(Control form)
        {
            for (var i = 0; i < Count; i++)
            {
                BlockType = random.NextEnum<BlockTypes>();
                Orientation = random.NextEnum<Orientation>();
                var quantity = random.Next(3, 9);

                switch (BlockType)
                {
                    case BlockTypes.Line:
                        CreateLine(form, Orientation, X * i * 6, Y, quantity);
                        break;
                    case BlockTypes.L:
                        CreateRandomForm(form, Orientation, X * i * 6, Y, quantity);
                        break;
                    default:
                        CreateRandomForm(form, Orientation, X * i * 6, Y, quantity);
                        break;
                }
            }
        }

        private void CreateRandomForm(Control form, Orientation orientation, int x, int y, int quantity)
        {
            int chance;

            for (var i = 0; i < quantity; i++)
            {
                Block block = new Block(x, y);
                BlocksList.Add(block);

                switch (orientation)
                {
                    case Orientation.Horizontal:
                        if(i % 2 != 0 || i == 0)
                        {
                            //block = new Block(form, x, y);
                            block.SetLocation(x, y);
                            
                            x = i == 0 ? x + Block.Size : x;
                        }
                        else
                        {
                            chance = random.Next(2);
                            y = chance == 0 ? y + Block.Size : y - Block.Size;
                            //block = new Block(form, x, y);
                            block.SetLocation(x, y);

                            x += Block.Size;
                            y = chance == 0 ? y - Block.Size : y + Block.Size;
                        }
                        break;
                    case Orientation.Vertical:
                        if (i % 2 != 0 || i == 0)
                        {
                            //block = new Block(form, x, y);
                            block.SetLocation(x, y);
                            y = i == 0 ? y + Block.Size : y;
                        }
                        else
                        {
                            chance = random.Next(2);
                            x = chance == 0 ? x + Block.Size : x - Block.Size;
                            //block = new Block(form, x, y);
                            block.SetLocation(x, y);

                            y += Block.Size;
                            x = chance == 0 ? x - Block.Size : x + Block.Size;
                        }
                        break;
                }
            }
        }

        private void CreateLine(Control form, Orientation orientation, int x, int y, int quantity)
        {
            for (var i = 0; i < quantity; i++)
            {
                Block block = new Block(x, y);
                BlocksList.Add(block);

                switch (orientation)
                {
                    case Orientation.Horizontal:
                        block.SetX(x + i * Block.Size);
                        break;
                    case Orientation.Vertical:
                        block.SetY(y + i * Block.Size);
                        break;
                }
            }
        }
    }
}
