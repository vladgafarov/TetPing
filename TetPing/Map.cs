using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetPing
{
    class Map
    {
        public static int[,] map;
        private static int mapHeight = 15;
        private static int mapWidth = 15;
        public static List<Block> BlocksList = new List<Block>();

        public Map(Control form)
        {
            map = new int[mapHeight, mapWidth];
            //map[0, 0] = 1;
            //map[0, 1] = 1;
            //map[0, 2] = 1;
            //map[1, 2] = 1;
            //map[2, 5] = 1;
            //map[10, 10] = 1;
            //map[10, 11] = 1;
            //Init();
        }

        public static void Init()
        {
            for(var i = 0; i < mapHeight; i++)
            {
                for(var j = 0; j < mapWidth; j++)
                {
                    if (map[i, j] == 1)
                    {
                        var block = new Block(i, j);
                        BlocksList.Add(block);
                    }
                }
            }
        }
    }
}
