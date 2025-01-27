﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    class Map
    {
        public static BlockType[,] map;
        public static int mapHeight = 18;
        public static int mapWidth = 15;
        public static List<Block> BlocksList = new List<Block>();

        public Map()
        {
            map = new BlockType[mapHeight, mapWidth];
        }

        public static void Init()
        {
            for(var y = 0; y < mapHeight; y++)
            {
                for(var x = 0; x < mapWidth; x++)
                {
                    if (map[y, x] != BlockType.None)
                    {
                        var block = new Block(x, y, map[y, x]);
                        BlocksList.Add(block);
                    }
                }
            }
        }

        public static void Reset()
        {
            BlocksList.Clear();
            ResetMap();
            Block.CreateBlocks(6, 4);
        }

        public static void ResetMap()
        {
            for (var y = 0; y < mapHeight; y++)
            {
                for (var x = 0; x < mapWidth; x++)
                {
                    map[y, x] = BlockType.None;
                }
            }
        }

        public static bool IsHiddenPartEmpty(int heightForSearching)
        {
            var count = 0;
            var countShould = mapWidth * heightForSearching;

            for (int i = 0; i < mapWidth; i++)
            {   
                for (int j = 0; j < heightForSearching; j++)
                {
                    if (map[j, i] == BlockType.None)
                        count++;
                }
            }

            return count == countShould;
        }
    }
}
