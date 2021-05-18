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
        public BlockType Type;
        private Image BlockTexture;
        private Rectangle block;
        private int MapX;
        private int MapY;
        private int Y;

        private static Random random = new Random();

        public Block() 
        {
            CreateBlocks(6, 4);
        }

        public Block(int x, int y, BlockType type)
        {
            MapX = x;
            MapY = y;
            Y = y;
            Type = type;

            if (Type == BlockType.Ball)
                BlockTexture = Resources.Resource1.blockBall;
            else if (Type == BlockType.BoardSpeed)
                BlockTexture = Resources.Resource1.blockExtraPoints;
            else if (Type == BlockType.BallSpeed)
                BlockTexture = Resources.Resource1.blockAddSpeed;
            else if (Type == BlockType.Heart)
                BlockTexture = Resources.Resource1.blockAddHeart;
            else if (Type == BlockType.Standart)
                BlockTexture = Resources.Resource1.blockNew;

            Y -= 3;
            block = new Rectangle(x * Size, Y * Size, Size, Size);
        }

        #region utils

        public void SetY(int y)
        {
            block.Y = y * Size;
        }

        public void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(BlockTexture, block);
        }

        public void Remove()
        {
            var index = Map.BlocksList.IndexOf(this);
            if(index >= 0)
            {
                Map.map[MapY, MapX] = 0;
                Map.BlocksList.RemoveAt(index);
            }
        }

        public Rectangle GetRectBlock()
        {
            return block;
        }
        #endregion

        public static void CreateBlocks(int count, int y)
        {
            BlocksTypes BlocksTypes;
            Orientation Orientation;

            var lastX = 1;

            for (var i = 0; i < count; i++)
            {
                BlocksTypes = random.NextEnum<BlocksTypes>();
                Orientation = random.NextEnum<Orientation>();
                var quantity = random.Next(3, 9);

                switch (BlocksTypes)
                {
                    case BlocksTypes.Line:
                        lastX = CreateLine(Orientation, lastX, y, quantity);
                        break;
                    case BlocksTypes.Random:
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
                var type = GetRandomBlockType();

                if (x >= Map.mapWidth - 1) break;
                switch (orientation)
                {
                    case Orientation.Horizontal:
                        if (i % 2 != 0 || i == 0)
                        {
                            Map.map[y, x] = type;
                            x = i == 0 ? x + 1 : x;
                        }
                        else
                        {
                            chance = random.Next(2);
                            y = chance == 0 ? y + 1 : y - 1;
                            Map.map[y, x] = type;

                            x += 1;
                            y = chance == 0 ? y - 1 : y + 1;
                        }
                        break;
                    case Orientation.Vertical:
                        if (i % 2 != 0 || i == 0)
                        {
                            Map.map[y, x] = type;
                            y = i == 0 ? y + 1 : y;
                        }
                        else
                        {
                            chance = random.Next(2);
                            x = chance == 0 ? x + 1 : x - 1;
                            if(x > 0)
                                Map.map[y, x] = type;

                            y += 1;
                            x = chance == 0 ? x - 1 : x + 1;
                        }
                        break;
                }
            }

            return x + 1;
        }

        private static int CreateLine(Orientation orientation, int x, int y, int quantity)
        {
            var lastX = x;

            for (var i = 0; i < quantity; i++)
            {
                var type = GetRandomBlockType();

                if (x + i >= Map.mapWidth - 1) break;
                switch (orientation)
                {
                    case Orientation.Horizontal:
                        Map.map[y, x + i] = type;
                        lastX = x + i;
                        break;
                    case Orientation.Vertical:
                        Map.map[y + i, x] = type;
                        break;

                }
            }
            return lastX + 2;
        }

        public void DownShift()
        {
            var nextY = Y + 1;

            if (nextY == Map.mapHeight - 3)
                Game.EndGame();
            else
            {
                SetY(nextY);
                Map.map[MapY, MapX] = 0;
                Map.map[MapY + 1, MapX] = Type;

                Y += 1;
                MapY += 1;
            }
        }

        private static BlockType GetRandomBlockType()
        {
            var BlockTypeBallRandom = 20;

            var type = BlockType.Standart;
            var BlockTypeChance = random.Next(BlockTypeBallRandom);
            var BlockAddHeartChance = random.Next(50);

            if (BlockTypeChance == 0) //5%
                type = BlockType.Ball;
            else if (BlockTypeChance == 1 || BlockTypeChance == 2) //10%
                type = BlockType.BoardSpeed;
            else if (BlockTypeChance == 3) //5%
                type = BlockType.BallSpeed;
            if (BlockAddHeartChance == 0) //2%
                type = BlockType.Heart;

            return type;
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
